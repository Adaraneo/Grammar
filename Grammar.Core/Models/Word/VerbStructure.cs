using Grammar.Core.Enums;

namespace Grammar.Core.Models.Word
{
    /// <summary>
    /// Represents analyzed stems and affixes used for Czech verb conjugation.
    /// </summary>
    public sealed class VerbStructure
    {
        /// <summary>
        /// Gets or sets the analyzed prefix.
        /// </summary>
        public string? Prefix { get; set; }

        /// <summary>
        /// Gets or sets the stem used for present forms.
        /// </summary>
        public string PresentStem { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the stem used for past forms.
        /// </summary>
        public string PastStem { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the stem used for passive forms.
        /// </summary>
        public string? PassiveStem { get; set; }

        /// <summary>
        /// Gets or sets the stem used for imperative forms.
        /// </summary>
        public string? ImperativeStem { get; set; }

        /// <summary>
        /// Gets or sets the requested or resolved verb aspect.
        /// </summary>
        public VerbAspect Aspect { get; set; }
    }
}
