using Grammar.Core.Enums;

namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Represents valency slot.
    /// </summary>
    public sealed record ValencySlot
    {
        /// <summary>
        /// Gets or sets the semantic role represented by the slot.
        /// </summary>
        public SemanticRole Role { get; init; }

        /// <summary>
        /// Gets the syntactic realization required by the valency slot.
        /// </summary>
        public SyntacticRealization Realization { get; init; } = new();

        /// <summary>
        /// Gets a value indicating whether the valency slot must be expressed.
        /// </summary>
        public bool IsObligatory { get; init; }
    }
}
