using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents Czech preposition metadata loaded from JSON data.
    /// </summary>
    public sealed record PrepositionData
    {
        /// <summary>
        /// Gets the preposition lemma or surface form.
        /// </summary>
        public string Preposition { get; init; } = "";
        /// <summary>
        /// Gets the origin category of the preposition.
        /// </summary>
        public PrepositionOriginType OriginType { get; init; }
        /// <summary>
        /// Gets the case and semantic variants supported by the preposition.
        /// </summary>
        public List<PrepositionVariant> Variants { get; init; } = new();
    }

    /// <summary>
    /// Represents one surface variant of a Czech preposition.
    /// </summary>
    public sealed record PrepositionVariant
    {
        /// <summary>
        /// Gets or sets the requested grammatical case.
        /// </summary>
        public Case Case { get; init; }
        /// <summary>
        /// Gets the semantic group represented by the preposition variant.
        /// </summary>
        public PrepositionSemanticGroup SemanticGroup { get; init; }
    }
}
