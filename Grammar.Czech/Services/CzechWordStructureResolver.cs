using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;
using Grammar.Core.Interfaces;
using Grammar.Core.Models;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechWordStructureResolver : IWordStructureResolver<CzechWordRequest>
    {
        private readonly Dictionary<string, VerbPattern> verbPatterns;
        private readonly Dictionary<string, VerbPattern> irregularVerbPatterns;
        private readonly CzechPrefixService prefixService;
        public CzechWordStructureResolver(IVerbDataProvider dataProvider, CzechPrefixService prefixService)
        {
            this.irregularVerbPatterns = dataProvider.GetIrregulars();
            this.verbPatterns = dataProvider.GetPatterns();
            this.prefixService = prefixService;
        }

        public WordStructure AnalyzeStructure(CzechWordRequest wordRequest)
        {
            return wordRequest.WordCategory switch
            {
                WordCategory.Noun => GetPrefixAndStemForNoun(wordRequest),
                WordCategory.Adjective => GetPrefixAndStemForAdjective(wordRequest),
                WordCategory.Verb => GetPrefixAndStemForVerb(wordRequest, verbPatterns, irregularVerbPatterns),
                _ => new WordStructure { Root = wordRequest.Lemma, Ending = string.Empty }
            };
        }

        private WordStructure GetPrefixAndStemForNoun(CzechWordRequest word)
        {
            var lemma = word.Lemma;
            var patternName = word.Pattern;
            string prefix = null;

            if (word.Pattern == "žena" && lemma.EndsWith("ka") && lemma.Length > 2)
            {
                return new WordStructure
                {
                    Root = lemma[..^2],
                    DerivationSuffix = (word.Case == Case.Genitive && word.Number == Number.Plural) ? string.Empty : "k",
                    Ending = "a"
                };
            }

            if (lemma.EndsWith(patternName[^1]))
            {
                return new WordStructure
                {
                    Prefix = prefix,
                    Root = lemma[..^1]
                };
            }

            if (MorphologyHelper.EndsWithVowelConsonantVowelConsonant(lemma) && word.Case != Case.Nominative)
            {
                return new WordStructure
                {
                    Prefix = prefix,
                    Root = lemma[..^2] + lemma[^1]
                };
            }

            return new WordStructure { Prefix = prefix, Root = lemma };
        }

        private WordStructure GetPrefixAndStemForAdjective(CzechWordRequest word)
        {
            var lemma = word.Lemma;
            var patternName = word.Pattern;
            string prefix = null;

            if (lemma.EndsWith(patternName[^1]))
            {
                return new WordStructure { Prefix = prefix, Root = lemma[..^1] };
            }

            if (MorphologyHelper.EndsWithVowelConsonantVowelConsonant(lemma) && word.Case != Case.Nominative)
            {
                return new WordStructure { Prefix = prefix, Root = lemma[..^2] + lemma[^1] };
            }

            return new WordStructure { Prefix = prefix, Root = lemma };
        }

        private WordStructure GetPrefixAndStemForVerb(CzechWordRequest word, Dictionary<string, VerbPattern> verbPatterns, Dictionary<string, VerbPattern> irregularVerbPatterns)
        {
            var lemma = word.Lemma;
            var patternName = word.Pattern;
            string prefix = prefixService.FindPerfectivePrefix(lemma);

            if (prefix != null)
            {
                lemma = lemma.Substring(prefix.Length);
            }

            if (verbPatterns.TryGetValue(patternName, out var pattern))
            {
                var stem = GetStemForTense(pattern, word);
                return new WordStructure { Prefix = prefix, Root = stem };
            }
            else if (irregularVerbPatterns.TryGetValue(patternName, out pattern))
            {
                var stem = GetStemForTense(pattern, word);
                return new WordStructure { Prefix = prefix, Root = stem };
            }

            // Fallback heuristiky
            if (patternName.StartsWith("trida"))
            {
                if (lemma.EndsWith("ovat")) return new WordStructure { Prefix = prefix, Root = lemma[..^4] };             // pracovat → prac
                if (lemma.EndsWith("nout")) return new WordStructure { Prefix = prefix, Root = lemma[..^4] };             // klesnout → kles
                if (lemma.EndsWith("ít")) return new WordStructure { Prefix = prefix, Root = lemma[..^2] };               // sázet → sáz
                if (lemma.EndsWith("ět") || lemma.EndsWith("et")) return new WordStructure { Prefix = prefix, Root = lemma[..^2] }; // myslet → mysl
                if (lemma.EndsWith("it")) return new WordStructure { Prefix = prefix, Root = lemma[..^2] };               // prosit → pros
                if (lemma.EndsWith("át") || lemma.EndsWith("at")) return new WordStructure { Prefix = prefix, Root = lemma[..^2] }; // zpívat → zpív

                return new WordStructure { Prefix = prefix, Root = lemma.Substring(0, lemma.Length - 1) }; // fallback
            }

            if (lemma == patternName && word.WordCategory == WordCategory.Verb)
                return new WordStructure { Prefix = prefix, Root = lemma };

            if (lemma.EndsWith(patternName[^1]))
                return new WordStructure { Prefix = prefix, Root = lemma[..^1] };

            return new WordStructure { Prefix = prefix, Root = lemma }; // ultimate fallback
        }

        private string GetStemForTense(VerbPattern pattern, CzechWordRequest request)
        {
            return request.Tense switch
            {
                Tense.Present => pattern.PresentStem ?? pattern.Stem ?? throw new InvalidOperationException("Missing Present stem."),
                Tense.Past => pattern.PastStem ?? pattern.Stem ?? throw new InvalidOperationException("Missing Past stem."),
                Tense.Future when pattern.Aspect == VerbAspect.Perfective => pattern.FutureStem ?? pattern.PresentStem ?? pattern.Stem ?? throw new InvalidOperationException("Missing Future stem."),
                Tense.Future when pattern.Aspect == VerbAspect.Imperfective && request.Lemma == "být" => pattern.FutureStem ?? throw new InvalidOperationException("Missing Future stem for 'být'"),
                Tense.Future when pattern.Aspect == VerbAspect.Imperfective => pattern.Infinitive ?? request.Lemma ?? throw new InvalidOperationException("Missing infinitive!"),
                _ => pattern.PassiveStem ?? pattern.Stem ?? throw new InvalidOperationException("Missing base or passive stem.")
            };
        }

    }
}
