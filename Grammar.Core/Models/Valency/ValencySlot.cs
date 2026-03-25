using Grammar.Core.Enums;

namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Represents a single argument position within a <see cref="ValencyFrame"/>.
    /// </summary>
    /// <remarks>
    /// Each slot binds a thematic (semantic) role to its syntactic realisation.
    /// Optional slots represent adjuncts or arguments that may be omitted.
    /// </remarks>
    public sealed record ValencySlot
    {
        /// <summary>Gets the thematic role this slot expresses (e.g., Actor, Patient).</summary>
        public SemanticRole Role { get; init; }

        /// <summary>Gets the syntactic realisation: the case and optional preposition.</summary>
        public SyntacticRealization Realization { get; init; } = new();

        /// <summary>
        /// Gets a value indicating whether this slot must be filled for the sentence to be grammatical.
        /// </summary>
        public bool IsObligatory { get; init; }
    }
}
