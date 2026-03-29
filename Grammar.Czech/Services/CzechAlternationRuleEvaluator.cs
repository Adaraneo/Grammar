using Grammar.Core.Interfaces;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechAlternationRuleEvaluator : IAlternationRuleEvaluator
    {
        private readonly IPhonemeRegistry _registry;
        private readonly IValencyProvider<CzechLexicalEntry> _valencyProvider;

        public CzechAlternationRuleEvaluator(IPhonemeRegistry registry, IValencyProvider<CzechLexicalEntry> valencyProvider)
        {
            this._registry = registry;
            _valencyProvider = valencyProvider;
        }

        public bool ShouldShortenGenitivePlural(CzechWordRequest request, NounPattern pattern)
        {
            return request.HasGenitivePluralShortening
                ?? _valencyProvider.GetEntry(request.Lemma)?.HasGenitivePluralShortening
                ?? false;
        }
    }
}
