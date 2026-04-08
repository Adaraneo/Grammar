using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to adjective data.
    /// </summary>
    public interface IAdjectiveDataProvider
    {
        /// <summary>
        /// Gets regular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded adjective declension patterns keyed by pattern name.</returns>
        Dictionary<string, AdjectivePattern> GetPatterns();
    }
}
