using Grammar.Core.Enums;
using Grammar.Core.Interfaces;
using Grammar.Core.Models;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using Microsoft.Extensions.Logging;

namespace Grammar.Czech.Services
{
    public class CzechWordStructureResolver : IWordStructureResolver<CzechWordRequest>
    {
        private readonly IVerbDataProvider verbDataProvider;
        private readonly CzechPrefixService prefixService;

        private readonly Dictionary<WordCategory, Func<CzechWordRequest, WordStructure>> analyzers;

        public CzechWordStructureResolver(IVerbDataProvider verbDataProvider, CzechPrefixService prefixService)
        {
            this.verbDataProvider = verbDataProvider;
            this.prefixService = prefixService;

            analyzers = new Dictionary<WordCategory, Func<CzechWordRequest, WordStructure>>
            {
                { WordCategory.Noun, AnalyzeNoun },
                { WordCategory.Verb, AnalyzeVerb },
                { WordCategory.Adjective, AnalyzeAdjective },
                { WordCategory.Pronoun, AnalyzePronoun }
            };
        }

        public WordStructure AnalyzeStructure(CzechWordRequest wordRequest)
        {
            ValidateRequest(wordRequest);

            if (!analyzers.TryGetValue(wordRequest.WordCategory, out var analyzer))
            {
                throw new NotSupportedException($"Word category '{wordRequest.WordCategory}' is not supported.");
            }

            var result = analyzer(wordRequest);

            return result;
        }

        private void ValidateRequest(CzechWordRequest wordRequest)
        {
            if (string.IsNullOrEmpty(wordRequest.Lemma))
            {
                throw new ArgumentException("Lemma cannot be null or empty.", nameof(wordRequest));
            }

            if (string.IsNullOrEmpty(wordRequest.Pattern))
            {
                throw new ArgumentException("Pattern cannost be empty.", nameof(wordRequest));
            }
        }

        private WordStructure AnalyzeNoun(CzechWordRequest wordRequest)
        {
            // TODO: Implement noun structure analysis logic here
            throw new NotImplementedException();
        }

        private WordStructure AnalyzeVerb(CzechWordRequest wordRequest)
        {
            var prefix = ExtractPrefix(wordRequest.Lemma);
            var lemmaWithoutPrefix = prefix != null ? wordRequest.Lemma.Substring(prefix.Length) : wordRequest.Lemma;

            var stem = GetVerbStem(wordRequest, lemmaWithoutPrefix);

            return new WordStructure
            {
                Prefix = prefix,
                Root = stem
            };
        }

        private WordStructure AnalyzeAdjective(CzechWordRequest wordRequest)
        {
            // TODO: Implement adjective structure analysis logic here
            throw new NotImplementedException();
        }

        private string? ExtractPrefix(string lemma)
        {
            return prefixService.FindPerfectivePrefix(lemma);
        }

        private string GetVerbStem(CzechWordRequest wordRequest, string lemmaWithoutPrefix)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        private WordStructure AnalyzePronoun(CzechWordRequest wordRequest)
        {
            return new WordStructure
            {
                Root = wordRequest.Lemma
            };
        }
    }
}
