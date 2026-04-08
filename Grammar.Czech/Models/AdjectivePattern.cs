namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents endings and metadata for a Czech adjective declension pattern.
    /// </summary>
    public sealed record AdjectivePattern
    {
        /// <summary>
        /// Gets or sets inflection endings grouped by grammatical categories.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, List<string>>> Endings { get; init; }
        /// <summary>
        /// Gets or sets the pattern type.
        /// </summary>
        public string Type { get; init; }
    }
}
