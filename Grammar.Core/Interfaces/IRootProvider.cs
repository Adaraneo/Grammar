using Grammar.Core.Models.Derivation;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Provides access to the morphological root lexicon.
    /// </summary>
    /// <remarks>
    /// Language-specific implementations (e.g., <c>ICzechRootProvider</c>) extend this interface
    /// to expose typed root entries with language-specific derivation metadata.
    /// </remarks>
    public interface IRootProvider
    {
        /// <summary>
        /// Returns the root entry for the given root key, or <c>null</c> if not found.
        /// </summary>
        /// <param name="root">The morphological root string (e.g., "mlad").</param>
        RootEntry? GetByRoot(string root);

        /// <summary>
        /// Finds the root entry that contains a derivation link for the given lemma,
        /// or <c>null</c> if no root claims that lemma.
        /// </summary>
        /// <param name="lemma">The derived lemma to look up (e.g., "mladík").</param>
        RootEntry? GetByLemma(string lemma);
    }
}
