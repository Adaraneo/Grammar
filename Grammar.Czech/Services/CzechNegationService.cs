using Grammar.Core.Interfaces;
using Grammar.Core.Models.Word;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    /// <summary>
    /// Provides Czech negation operations.
    /// </summary>
    public class CzechNegationService : INegationService<CzechWordRequest>
    {
        private readonly CzechAuxiliaryVerbService auxiliaryVerbService;
        private readonly CzechPrefixService prefixService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CzechNegationService"/> type.
        /// </summary>
        public CzechNegationService(CzechAuxiliaryVerbService auxiliaryVerbService, CzechPrefixService prefixService)
        {
            this.auxiliaryVerbService = auxiliaryVerbService;
            this.prefixService = prefixService;
        }

        /// <summary>
        /// Applies Czech negation to the requested word form.
        /// </summary>
        /// <param name="request">The Czech word request to process.</param>
        /// <param name="baseForm">The form before negation is applied.</param>
        /// <returns>The negated Czech word form.</returns>
        public WordForm ApplyNegation(CzechWordRequest request, string baseForm)
        {
            if (request.Lemma == "být")
            {
                return new WordForm(auxiliaryVerbService.GetBeForm(request.Tense, request.Number, request.Person, request.Modus, request.Gender, isNegative: true));
            }

            return new WordForm($"{prefixService.GetNegativePrefix()}{baseForm}");
        }
    }
}
