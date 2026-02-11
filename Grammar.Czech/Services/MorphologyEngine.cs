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
    public class MorphologyEngine : IInflectionService<CzechWordRequest>, IVerbInflectionService<CzechWordRequest>
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

        /// <summary>
        /// Retrieves the basic form (infinitive) of a Czech verb based on the specified word request.
        /// </summary>
        /// <param name="wordRequest">An object containing the word and its grammatical category. The word category must be <see
        /// cref="WordCategory.Verb"/>.</param>
        /// <returns>A <see cref="WordForm"/> representing the basic form of the specified verb.</returns>
        /// <exception cref="NotSupportedException">Thrown if <paramref name="wordRequest"/> specifies a word category other than <see
        /// cref="WordCategory.Verb"/>.</exception>
        public WordForm GetBasicForm(CzechWordRequest wordRequest)
        {
            return wordRequest.WordCategory switch
            {
                WordCategory.Verb => verbConjugationService.GetBasicForm(wordRequest),
                _ => throw new NotSupportedException($"Basic form retrieval is only supported for verbs. Category: {wordRequest.WordCategory}")
            };
        }

        /// <summary>
        /// Returns the inflected form of a Czech word based on its grammatical category.
        /// </summary>
        /// <param name="word">A request containing the Czech word and its grammatical category. Cannot be null.</param>
        /// <returns>A <see cref="WordForm"/> representing the inflected form of the specified word.</returns>
        /// <exception cref="NotSupportedException">Thrown if the <paramref name="word"/> specifies a word category that is not supported.</exception>
        public WordForm GetForm(CzechWordRequest word)
        {
            return word.WordCategory switch
            {
                WordCategory.Noun => nounDeclensionService.GetForm(word),
                WordCategory.Adjective => adjectiveDeclensionService.GetForm(word),
                WordCategory.Pronoun => pronounService.GetForm(word),
                _ => throw new NotSupportedException($"Unsupported category: {word.WordCategory}")
            };
        }
    }
}
