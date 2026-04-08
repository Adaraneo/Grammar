namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents endings and overrides for a Czech noun declension pattern.
    /// </summary>
    public sealed record NounPattern
    {
        /// <summary>
        /// Gets or sets inflection endings grouped by grammatical categories.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Endings { get; init; }
        /// <summary>
        /// Gets or sets the requested grammatical gender.
        /// </summary>
        public string Gender { get; init; }

        /// <summary>
        /// Gets or sets explicit forms that override regular pattern generation.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>>? Overrides { get; init; }
        /// <summary>
        /// Gets or sets the stem used by the pattern.
        /// </summary>
        public string? Stem { get; init; }
        /// <summary>
        /// Gets or sets the base pattern key inherited by this pattern.
        /// </summary>
        public string? InheritsFrom { get; init; }
    }
}
