using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines operations for verb Inflection behavior.
    /// </summary>
    public interface IVerbInflectionService<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Builds the basic verb form without phrase-level auxiliaries.
        /// </summary>
        /// <param name="wordRequest">The word request to analyze or inflect.</param>
        /// <returns>The generated basic verb form.</returns>
        WordForm GetBasicForm(TWord wordRequest);
    }
}
