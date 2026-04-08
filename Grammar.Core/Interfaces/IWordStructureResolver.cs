using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines operations for resolving word Structure.
    /// </summary>
    public interface IWordStructureResolver<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Analyzes the morphological structure of the requested word.
        /// </summary>
        /// <param name="wordRequest">The word request to analyze or inflect.</param>
        /// <returns>The analyzed root, prefix, and suffix structure.</returns>
        WordStructure AnalyzeStructure(TWord wordRequest);
    }
}
