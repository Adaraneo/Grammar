using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to verb data.
    /// </summary>
    public interface IVerbDataProvider
    {
        /// <summary>
        /// Gets regular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded verb conjugation patterns keyed by pattern name.</returns>
        Dictionary<string, VerbPattern> GetPatterns();

        /// <summary>
        /// Gets irregular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded irregular verb patterns keyed by lemma or pattern name.</returns>
        Dictionary<string, VerbPattern> GetIrregulars();
    }
}
