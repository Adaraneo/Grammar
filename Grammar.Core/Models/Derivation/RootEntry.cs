namespace Grammar.Core.Models.Derivation
{
    /// <summary>
    /// Represents a morphological root together with all lexemes that can be derived from it.
    /// </summary>
    /// <remarks>
    /// A root is the shared phonological base across a derivational family.
    /// For example, the root <c>"mlad"</c> underlies <c>mladý</c>, <c>mládí</c>,
    /// <c>mladík</c>, and <c>mladost</c>.
    /// Language-specific providers (e.g., <c>JsonRootProvider</c>) return typed subclasses
    /// with richer metadata.
    /// </remarks>
    public sealed record RootEntry
    {
        /// <summary>Gets the morphological root string (e.g., "mlad").</summary>
        public string Root { get; init; } = string.Empty;

        /// <summary>Gets the collection of derivation links originating from this root.</summary>
        public IReadOnlyList<DerivationLink> Derivations { get; init; } = [];
    }
}
