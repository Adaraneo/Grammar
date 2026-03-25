namespace Grammar.Czech.Models.Derivation
{
    /// <summary>
    /// Represents a Czech morphological root together with all Czech derivation links
    /// registered under it.
    /// </summary>
    /// <remarks>
    /// This is the Czech-specific counterpart of <c>RootEntry</c> from <c>Grammar.Core</c>.
    /// It exposes a typed <see cref="Derivations"/> list of <see cref="CzechDerivationLink"/>
    /// so that consumers in the Czech layer do not need to cast the base-class list.
    /// The <c>JsonRootProvider</c> maps this type to <c>RootEntry</c> when the
    /// language-agnostic <c>IRootProvider</c> interface is called.
    /// </remarks>
    public sealed record CzechRootEntry
    {
        /// <summary>Gets the morphological root string (e.g., "mlad").</summary>
        public string Root { get; init; } = string.Empty;

        /// <summary>Gets all Czech derivation links registered under this root.</summary>
        public IReadOnlyList<CzechDerivationLink> Derivations { get; init; } = [];
    }
}
