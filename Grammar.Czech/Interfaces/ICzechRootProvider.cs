using Grammar.Core.Interfaces;
using Grammar.Czech.Models.Derivation;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides typed access to Czech root entries, extending the language-agnostic
    /// <see cref="IRootProvider"/> with methods that return <see cref="CzechRootEntry"/>
    /// and its typed <c>CzechDerivationLink</c> collection.
    /// </summary>
    public interface ICzechRootProvider : IRootProvider
    {
        /// <summary>
        /// Returns the <see cref="CzechRootEntry"/> for the given root key,
        /// or <c>null</c> if not found.
        /// </summary>
        /// <param name="root">The morphological root string (e.g., "mlad").</param>
        CzechRootEntry? GetCzechByRoot(string root);

        /// <summary>
        /// Finds the <see cref="CzechRootEntry"/> that contains a derivation link
        /// for the given lemma, or <c>null</c> if no root claims that lemma.
        /// </summary>
        /// <param name="lemma">The derived lemma to look up (e.g., "mladík").</param>
        CzechRootEntry? GetCzechByLemma(string lemma);
    }
}
