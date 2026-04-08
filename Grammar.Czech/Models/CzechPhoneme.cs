using Grammar.Core.Models.Phonology;
using Grammar.Czech.Enums.Phonology;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents a Czech phoneme and its Czech-specific phonological metadata.
    /// </summary>
    public sealed record CzechPhoneme : Phoneme
    {
        /// <summary>
        /// Gets or sets palatalization Targets.
        /// </summary>
        public Dictionary<PalatalizationContext, string>? PalatalizationTargets { get; init; }
    }
}
