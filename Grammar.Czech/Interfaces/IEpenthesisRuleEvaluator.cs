using Grammar.Core.Interfaces;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Defines operations for evaluating epenthesis Rule rules.
    /// </summary>
    public interface IEpenthesisRuleEvaluator<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Determines whether epenthesis should apply to the supplied stem and suffix.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <param name="derivationSuffix">The derivational suffix that may require epenthesis.</param>
        /// <param name="wordRequest">The word request to analyze or inflect.</param>
        /// <returns>True when the condition is met; otherwise, false.</returns>
        bool ShouldApplyEpenthesis(string stem, string derivationSuffix, TWord wordRequest);
    }
}
