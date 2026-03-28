using Grammar.Core.Enums;
using Grammar.Core.Exceptions;
using Grammar.Core.Interfaces;
using Grammar.Core.Models.Word;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechNounDeclensionService : IInflectionService<CzechWordRequest>
    {
        private readonly INounDataProvider _dataProvider;
        private readonly IWordStructureResolver<CzechWordRequest> _wordStructureResolver;
        private readonly ICzechPhonologyService _phonologyService;
        private readonly ISofteningRuleEvaluator<CzechWordRequest> _softeningRuleEvaluator;
        private readonly IEpenthesisRuleEvaluator<CzechWordRequest> _epenthesisRuleEvaluator;
        private readonly IJotationRuleEvaluator<CzechWordRequest> _jotationRuleEvaluator;
        private readonly ICzechOrtographyService _ortographyService;
        private readonly IValencyProvider _valencyProvider;

        public CzechNounDeclensionService(INounDataProvider dataProvider, IWordStructureResolver<CzechWordRequest> wordStructureResolver, ICzechPhonologyService phonologyService, ISofteningRuleEvaluator<CzechWordRequest> softeningRuleEvaluator, IEpenthesisRuleEvaluator<CzechWordRequest> epenthesisRuleEvaluator, IJotationRuleEvaluator<CzechWordRequest> jotationRuleEvaluator, ICzechOrtographyService ortographyService, IValencyProvider valencyProvider)
        {
            this._dataProvider = dataProvider;
            this._wordStructureResolver = wordStructureResolver;
            this._phonologyService = phonologyService;
            this._softeningRuleEvaluator = softeningRuleEvaluator;
            this._epenthesisRuleEvaluator = epenthesisRuleEvaluator;
            this._jotationRuleEvaluator = jotationRuleEvaluator;
            this._ortographyService = ortographyService;
            this._valencyProvider = valencyProvider;
        }

        public WordForm GetForm(CzechWordRequest word)
        {
            if (_dataProvider.GetPropers().TryGetValue(word.Lemma, out var propers) && word.IsIndeclinable.HasValue && word.IsIndeclinable.Value)
            {
                return new WordForm(word.Lemma);
            }

            if (!_dataProvider.GetPatterns().TryGetValue(word.Pattern.ToLower(), out var pattern))
            {
                throw new NotSupportedException($"Noun pattern '{word.Pattern}' not found.");
            }

            if (word.IsPluralOnly.HasValue && word.IsPluralOnly.Value && word.Number == Number.Singular)
            {
                throw new InvalidOperationException($"{word.Lemma} se nevyskytuje v jednotném čísle.");
            }

            if (word.Case == Case.Nominative && (word.Number == Number.Singular || (word.IsPluralOnly.HasValue && word.IsPluralOnly.Value && word.Number == Number.Plural)))
            {
                return new WordForm(word.Lemma);
            }

            var isBaseWordPattern = word.Lemma == word.Pattern;

            var numberKey = word.Number == Number.Singular ? "singular" : "plural";
            var caseKey = word.Case.ToString();

            NounPattern? irregular = null;

            if (_dataProvider.GetIrregulars().TryGetValue(word.Lemma.ToLower(), out irregular))
            {
                if (irregular.Overrides != null &&
                    irregular.Overrides.TryGetValue(numberKey, out var cases) &&
                    cases.TryGetValue(caseKey, out var irregularForm))
                {
                    return new WordForm(irregularForm);
                }

                if (!string.IsNullOrEmpty(irregular.InheritsFrom))
                {
                    word.Pattern = irregular.InheritsFrom;
                }
            }

            if (!pattern.Endings.TryGetValue(numberKey, out var caseDict) ||
                !caseDict.TryGetValue(caseKey, out var ending))
                throw new InvalidOperationException($"Ending not found for {numberKey} {caseKey}.");

            // případná výjimka před výpočtem tvaru
            if (pattern.Overrides != null &&
                pattern.Overrides.TryGetValue(numberKey, out var caseOverrides) &&
                caseOverrides.TryGetValue(caseKey, out var overrideForm) &&
                isBaseWordPattern)
            {
                return new WordForm(overrideForm);
            }

            var wordStructure = _wordStructureResolver.AnalyzeStructure(word);
            var stem = wordStructure.Root;
            if (!string.IsNullOrEmpty(wordStructure.DerivationSuffix))
            {
                stem = _phonologyService.ApplyEpenthesis(_epenthesisRuleEvaluator.ShouldApplyEpenthesis(stem, wordStructure.DerivationSuffix, word), stem, wordStructure.DerivationSuffix);
            }

            if (!string.IsNullOrEmpty(irregular?.Stem))
            {
                stem = irregular.Stem;
            }

            if (!string.IsNullOrEmpty(pattern.Stem) && isBaseWordPattern)
            {
                stem = pattern.Stem!;
            }

            if (_softeningRuleEvaluator.ShouldApplySoftening(word, out var palatalizationContext))
            {
                stem = _phonologyService.ApplySoftening(stem, palatalizationContext);
            }

            var hasMobileVowelRemoval = MorphologyHelper.EndsWithVowelConsonantVowelConsonant(word.Lemma);

            var finalEnding = _softeningRuleEvaluator.GetEndingTransformation(word, out var endingTransformationApplied) ?? ending;

            if (_jotationRuleEvaluator.ShouldApplyJotation(word, stem, finalEnding, hasMobileVowelRemoval))
            {
                finalEnding = _ortographyService.ApplyJotationOrthography(finalEnding);
            }
            else if (!endingTransformationApplied)
            {
                finalEnding = _ortographyService.NormalizeEndingOrthography(stem, finalEnding);
            }

            return new WordForm(MorphologyHelper.ApplyFormEnding(stem, finalEnding));
        }

        /// <summary>
        /// Resolves the gender, inflectional pattern, grammatical number, and animacy
        /// for the given lemma by looking it up in the lexical dictionary.
        /// </summary>
        /// <param name="lemma">The dictionary form of the noun.</param>
        /// <returns>
        /// Tuple (Gender, pattern, Number, isAnimate, hasMobileVowel) z lexicon.json.
        /// </returns>
        /// <exception cref="LemmaNotFoundException">
        /// Thrown when the lemma is not registered in the lexicon.
        /// Add a <c>LexicalEntry</c> for it in <c>lexicon.json</c>.
        /// </exception>
        public (Gender gender, string pattern, Number number, bool isAnimate, bool? hasMobileVowel) ResolveGenderAndPattern(string lemma)
        {
            var entry = _valencyProvider.GetEntry(lemma)
                ?? throw new LemmaNotFoundException(lemma);

            var gender = entry.Gender
                ?? throw new LemmaNotFoundException(lemma,
                    $"Lemma '{lemma}' found in lexicon but Gender is null.");

            var pattern = entry.Pattern
                ?? throw new LemmaNotFoundException(lemma,
                    $"Lemma '{lemma}' found in lexicon but Pattern is null.");

            return (gender, pattern, Number.Singular, entry.IsAnimate ?? false, entry.HasMobileVowel);
        }
    }
}
