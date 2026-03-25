using Grammar.Core.Enums;

namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Describes how a valency slot is realised syntactically:
    /// a grammatical case, optionally combined with a preposition.
    /// </summary>
    /// <example>
    /// Bare dative: <c>{ Case = Dative, Preposition = null }</c><br/>
    /// Directional: <c>{ Case = Accusative, Preposition = "na" }</c>
    /// </example>
    public sealed record SyntacticRealization
    {
        /// <summary>Gets the grammatical case in which this argument is realised.</summary>
        public Case Case { get; init; }

        /// <summary>
        /// Gets the preposition that governs the case, or <c>null</c> for a bare (prepositional-less) case.
        /// </summary>
        public string? Preposition { get; init; }
    }
}
