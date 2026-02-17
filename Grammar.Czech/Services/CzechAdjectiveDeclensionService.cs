using System.Text.Json;
using Grammar.Core.Enums;
using Grammar.Core.Interfaces;
using Grammar.Core.Models.Word;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using JL = Grammar.Core.Helpers.JsonLoader;

namespace Grammar.Czech.Services
{
    public class CzechAdjectiveDeclensionService : IInflectionService<CzechWordRequest>
    {
        private readonly IAdjectiveDataProvider dataProvider;
        private readonly IWordStructureResolver<CzechWordRequest> wordStructureResolver;

        public CzechAdjectiveDeclensionService(IAdjectiveDataProvider dataProvider, IWordStructureResolver<CzechWordRequest> wordStructureResolver)
        {
            this.dataProvider = dataProvider;
            this.wordStructureResolver = wordStructureResolver;
        }

        public WordForm GetForm(CzechWordRequest word)
        {
            if (!dataProvider.GetPatterns().TryGetValue(word.Pattern.ToLower(), out var pattern))
            {
                throw new NotSupportedException($"Adjective pattern '{word.Pattern}' not found.");
            }

            var numberKey = word.Number == Number.Singular ? "singular" : "plural";
            var genderKey = word.Gender.ToString();
            var caseIndex = (int)word.Case - 1;

            if (!pattern.Endings.TryGetValue(numberKey, out var genderDict) ||
                !genderDict.TryGetValue(genderKey, out var endings))
            {
                throw new InvalidOperationException($"Ending not found for {numberKey} {genderKey}.");
            }

            if (caseIndex < 0 || caseIndex >= endings.Count)
            {
                throw new IndexOutOfRangeException("Invalid case index for adjective.");
            }

            var wordSructure = wordStructureResolver.AnalyzeStructure(word);
            var (prefix, stem) = (wordSructure.Prefix, wordSructure.Root + wordSructure.DerivationSuffix);
            return new WordForm(MorphologyHelper.ApplyFormEnding(stem, endings[caseIndex]));
        }

        public string GuessAdjectivePattern(string lemma)
        {
            if (lemma.EndsWith("ý") || lemma.EndsWith("á") || lemma.EndsWith("é") || lemma.EndsWith("í"))
            {
                return lemma.EndsWith("í") ? "jarní" : "mladý";
            }

            return "mladý"; // fallback na tvrdý vzor
        }
    }
}