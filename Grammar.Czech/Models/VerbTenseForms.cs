namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents verb endings grouped by tense, number, and person.
    /// </summary>
    public sealed record VerbTenseForms
    {
        /// <summary>
        /// Gets or sets plural.
        /// </summary>
        public IReadOnlyDictionary<string, string>? Plural { get; init; }

        // Present/Future: number → person
        /// <summary>
        /// Gets or sets singular.
        /// </summary>
        public IReadOnlyDictionary<string, string>? Singular { get; init; }
    }
}
