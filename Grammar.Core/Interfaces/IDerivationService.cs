using Grammar.Core.Enums;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Constructs word requests for lexemes derived from a given morphological root.
    /// </summary>
    /// <typeparam name="TWord">The language-specific word request type.</typeparam>
    /// <remarks>
    /// The implementation resolves the root via <see cref="IRootProvider"/>, applies
    /// language-specific phonological alternations (via <c>IPhonemeRegistry</c>),
    /// and returns a fully populated word request ready for the inflection pipeline.
    /// </remarks>
    public interface IDerivationService<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Returns word requests for all derivation links registered under the given root key.
        /// </summary>
        /// <param name="rootKey">The morphological root string (e.g., "mlad").</param>
        IReadOnlyList<TWord> GetAllDerivedRequests(string rootKey);

        /// <summary>
        /// Returns a word request for the derivation of the specified type,
        /// or <c>null</c> if no such derivation is registered for the root.
        /// </summary>
        /// <param name="rootKey">The morphological root string (e.g., "mlad").</param>
        /// <param name="type">The derivation type to look up (e.g., Feminative).</param>
        TWord? GetDerivedRequest(string rootKey, DerivationType type);
    }
}
