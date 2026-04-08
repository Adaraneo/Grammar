using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents pronoun case forms.
    /// </summary>
    public sealed record PronounCaseForms
    {
        /// <summary>
        /// Gets or sets default.
        /// </summary>
        public string? Default { get; init; }

        /// <summary>
        /// Gets or sets after Preposition.
        /// </summary>
        public string? AfterPreposition { get; init; }

        /// <summary>
        /// Gets or sets clitic.
        /// </summary>
        public string? Clitic { get; init; }

        /// <summary>
        /// Gets or sets rare.
        /// </summary>
        public string? Rare { get; init; }
    }

    /// <summary>
    /// Represents Czech pronoun metadata loaded from JSON data.
    /// </summary>
    public sealed record PronounData
    {
        /// <summary>
        /// Gets or sets the pattern type.
        /// </summary>
        public PronounType Type { get; init; }

        /// <summary>
        /// Gets or sets inflection Class.
        /// </summary>
        public InflectionClass InflectionClass { get; init; }

        /// <summary>
        /// Gets or sets the requested grammatical person.
        /// </summary>
        public Person? Person { get; init; }
        /// <summary>
        /// Gets or sets the requested grammatical number.
        /// </summary>
        public Number? Number { get; init; }
        /// <summary>
        /// Gets or sets the requested grammatical gender.
        /// </summary>
        public Gender? Gender { get; init; }

        /// <summary>
        /// Gets or sets fixed Forms.
        /// </summary>
        public Dictionary<Case, PronounCaseForms>? FixedForms { get; init; }

        /// <summary>
        /// Gets or sets paradigm Id.
        /// </summary>
        public string? ParadigmId { get; init; }

        /// <summary>
        /// Gets or sets declension Pattern.
        /// </summary>
        public string? DeclensionPattern { get; init; }

        /// <summary>
        /// Gets or sets the analyzed prefix.
        /// </summary>
        public string? Prefix { get; init; }
    }
}
