using Grammar.Core.Interfaces;
using Grammar.Core.Models;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechNegationService : INegationService<CzechWordRequest>
    {
        private readonly CzechAuxiliaryVerbService auxiliaryVerbService;
        private readonly CzechPrefixService prefixService;

        public CzechNegationService(CzechAuxiliaryVerbService auxiliaryVerbService, CzechPrefixService prefixService)
        {
            this.auxiliaryVerbService = auxiliaryVerbService;
            this.prefixService = prefixService;
        }

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