using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines operations for inflection behavior.
    /// </summary>
    public interface IInflectionService<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Builds the requested inflected word form.
        /// </summary>
        /// <param name="wordRequest">The word request to analyze or inflect.</param>
        /// <returns>The generated inflected word form.</returns>
        WordForm GetForm(TWord wordRequest);
    }
}
