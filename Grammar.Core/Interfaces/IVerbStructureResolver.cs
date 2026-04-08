using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines operations for resolving verb Structure.
    /// </summary>
    public interface IVerbStructureResolver<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Analyzes stems and affixes needed to conjugate the requested verb.
        /// </summary>
        /// <param name="wordRequest">The word request to analyze or inflect.</param>
        /// <returns>The analyzed verb stems and prefix data.</returns>
        VerbStructure AnalyzeVerbStructure(TWord wordRequest);
    }
}
