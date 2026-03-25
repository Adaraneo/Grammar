namespace Grammar.Core.Models.Word
{
    /// <summary>
    /// Represents the internal morphological structure of a word form:
    /// an optional prefix, a root, an optional derivational suffix,
    /// and an optional reference back to the root lexicon.
    /// </summary>
    public sealed class WordStructure
    {
        /// <summary>Gets or sets the verbal prefix (e.g., "pře" in "přepsat").</summary>
        public string? Prefix { get; set; }

        /// <summary>Gets or sets the morphological root used to build inflected forms.</summary>
        public string Root { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the derivational suffix that is part of the stem
        /// (e.g., "k" in "studentka") and affects epenthesis and softening rules.
        /// </summary>
        public string? DerivationSuffix { get; set; }

        /// <summary>
        /// Gets or sets the key into <see cref="IRootProvider"/> identifying the
        /// morphological root family this word belongs to (e.g., "mlad" for "mladík").
        /// <c>null</c> when the root family is unknown or irrelevant.
        /// </summary>
        public string? RootKey { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"{Prefix}{Root}{DerivationSuffix}";
    }
}
