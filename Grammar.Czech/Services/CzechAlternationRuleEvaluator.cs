using Grammar.Core.Interfaces;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    /// <summary>
    /// Evaluates Czech alternation rule evaluator rules.
    /// </summary>
    public class CzechAlternationRuleEvaluator : IAlternationRuleEvaluator
    {
        private readonly IPhonemeRegistry _registry;
        private readonly IValencyProvider<CzechLexicalEntry> _valencyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CzechAlternationRuleEvaluator"/> type.
        /// </summary>
        public CzechAlternationRuleEvaluator(IPhonemeRegistry registry, IValencyProvider<CzechLexicalEntry> valencyProvider)
        {
            this._registry = registry;
            _valencyProvider = valencyProvider;
        }

        /// <summary>
        /// Determines whether should shorten genitive plural.
        /// </summary>
        /// <param name="request">The Czech word request to process.</param>
        /// <param name="pattern">The inflection pattern used to choose the rule.</param>
        /// <returns>True when the condition is met; otherwise, false.</returns>
        public bool ShouldShortenGenitivePlural(CzechWordRequest request, NounPattern pattern)
        {
            return request.HasGenitivePluralShortening
                ?? _valencyProvider.GetEntry(request.Lemma)?.HasGenitivePluralShortening
                ?? false;
        }
    }
}
