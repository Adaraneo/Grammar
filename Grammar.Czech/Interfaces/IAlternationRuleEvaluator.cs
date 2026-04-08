using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Defines operations for evaluating alternation Rule rules.
    /// </summary>
    public interface IAlternationRuleEvaluator
    {
        /// <summary>
        /// Determines whether should shorten genitive plural.
        /// </summary>
        /// <param name="request">The Czech word request to process.</param>
        /// <param name="pattern">The inflection pattern used to choose the rule.</param>
        /// <returns>True when the condition is met; otherwise, false.</returns>
        bool ShouldShortenGenitivePlural(CzechWordRequest request, NounPattern pattern);
    }
}
