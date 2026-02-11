using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;
using Grammar.Core.Interfaces;
using Grammar.Core.Models;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class MorphologyEngine : IInflectionService<CzechWordRequest>
    {
        private readonly CzechNounDeclensionService nounDeclensionService;
        private readonly CzechAdjectiveDeclensionService adjectiveDeclensionService;
        private readonly CzechPronounService pronounService;
        private readonly CzechVerbConjugationService verbConjugationService;

        public MorphologyEngine(CzechNounDeclensionService nounDeclensionService, CzechAdjectiveDeclensionService adjectiveDeclensionService, CzechPronounService pronounService, CzechVerbConjugationService verbConjugationService)
        {
            this.nounDeclensionService = nounDeclensionService;
            this.adjectiveDeclensionService = adjectiveDeclensionService;
            this.pronounService = pronounService;
            this.verbConjugationService = verbConjugationService;
        }

        public WordForm GetForm(CzechWordRequest word)
        {
            return word.WordCategory switch
            {
                WordCategory.Noun => nounDeclensionService.GetForm(word),
                WordCategory.Adjective => adjectiveDeclensionService.GetForm(word),
                WordCategory.Pronoun => pronounService.GetForm(word),
                WordCategory.Verb => verbConjugationService.GetBasicForm(word),
                _ => throw new NotSupportedException($"Unsupported category: {word.WordCategory}")
            };
        }
    }
}
