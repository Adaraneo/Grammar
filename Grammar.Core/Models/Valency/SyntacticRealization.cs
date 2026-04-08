using Grammar.Core.Enums;

namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Represents syntactic realization.
    /// </summary>
    public sealed record SyntacticRealization
    {
        /// <summary>
        /// Gets or sets the requested grammatical case.
        /// </summary>
        public Case Case { get; init; }

        /// <summary>
        /// Gets or sets preposition.
        /// </summary>
        public string? Preposition { get; init; }
    }
}
