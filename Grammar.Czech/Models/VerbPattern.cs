using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents stems, endings, and overrides for a Czech verb pattern.
    /// </summary>
    public sealed record VerbPattern
    {
        /// <summary>
        /// Gets or sets the requested or resolved verb aspect.
        /// </summary>
        public VerbAspect Aspect { get; init; }
        /// <summary>
        /// Gets or sets future.
        /// </summary>
        public VerbTenseForms Future { get; init; }
        /// <summary>
        /// Gets or sets the stem used for future forms.
        /// </summary>
        public string? FutureStem { get; init; }
        /// <summary>
        /// Gets or sets the stem used for imperative forms.
        /// </summary>
        public string? ImperativeStem { get; init; }
        /// <summary>
        /// Gets or sets infinitive.
        /// </summary>
        public string? Infinitive { get; init; }
        /// <summary>
        /// Gets or sets the base pattern key inherited by this pattern.
        /// </summary>
        public string? InheritsFrom { get; init; }
        /// <summary>
        /// Gets or sets passive Participle.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> PassiveParticiple { get; init; }
        /// <summary>
        /// Gets or sets the stem used for passive forms.
        /// </summary>
        public string? PassiveStem { get; init; }
        /// <summary>
        /// Gets or sets past Participle.
        /// </summary>
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> PastParticiple { get; init; }
        /// <summary>
        /// Gets or sets the stem used for past forms.
        /// </summary>
        public string? PastStem { get; init; }
        /// <summary>
        /// Gets or sets present.
        /// </summary>
        public VerbTenseForms Present { get; init; }
        /// <summary>
        /// Gets or sets the stem used for present forms.
        /// </summary>
        public string? PresentStem { get; init; }
        /// <summary>
        /// Gets or sets the stem used by the pattern.
        /// </summary>
        public string? Stem { get; init; }
    }
}
