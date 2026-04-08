using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for Word Form Composer.
    /// </summary>
    public interface IWordFormComposer<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Builds the complete requested word or phrase form.
        /// </summary>
        /// <param name="request">The Czech word request to process.</param>
        /// <returns>The composed word or phrase form.</returns>
        WordForm GetFullForm(TWord request);
    }
}
