namespace Grammar.Core.Models.Word
{
    /// <summary>
    /// Represents the analyzed root, prefixes, and suffixes of a word.
    /// </summary>
    public sealed class WordStructure
    {
        /// <summary>
        /// Gets or sets the analyzed prefix.
        /// </summary>
        public string? Prefix { get; set; }

        /// <summary>
        /// Gets or sets the analyzed root.
        /// </summary>
        public string Root { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the analyzed derivational suffix.
        /// </summary>
        public string? DerivationSuffix { get; set; }

        /// <summary>
        /// Returns the reconstructed word from its analyzed prefix, root, and derivational suffix.
        /// </summary>
        /// <returns>The reconstructed word structure.</returns>
        public override string ToString() => $"{Prefix}{Root}{DerivationSuffix}";
    }
}
