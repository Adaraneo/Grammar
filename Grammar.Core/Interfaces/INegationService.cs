using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines operations for negation behavior.
    /// </summary>
    public interface INegationService<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Applies language-specific negation to an already generated form.
        /// </summary>
        /// <param name="word">The word request that controls whether negation is needed.</param>
        /// <param name="baseForm">The form before negation is applied.</param>
        /// <returns>The negated word form, or the original form when negation is not requested.</returns>
        WordForm ApplyNegation(TWord word, string baseForm);
    }
}
