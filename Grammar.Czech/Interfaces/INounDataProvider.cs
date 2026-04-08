using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to noun data.
    /// </summary>
    public interface INounDataProvider
    {
        /// <summary>
        /// Gets regular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded noun declension patterns keyed by pattern name.</returns>
        Dictionary<string, NounPattern> GetPatterns();

        /// <summary>
        /// Gets irregular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded irregular noun patterns keyed by lemma or pattern name.</returns>
        Dictionary<string, NounPattern> GetIrregulars();

        /// <summary>
        /// Gets proper-name noun entries loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded proper-name noun entries keyed by lemma.</returns>
        Dictionary<string, NounPattern> GetPropers();
    }
}
