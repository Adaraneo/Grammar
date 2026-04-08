using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to preposition data.
    /// </summary>
    public interface IPrepositionDataProvider
    {
        /// <summary>
        /// Gets Czech preposition metadata loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded preposition data keyed by preposition form.</returns>
        Dictionary<string, PrepositionData> GetPrepositions();
    }
}
