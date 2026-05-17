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

        /// <summary>
        /// When false, this consonant does not trigger epenthesis when acting as C2
        /// in a genitive plural cluster. Covers: d, t, s, z, š, f, ch, p.
        /// Source: ÚJČ – endings -da, -ta, -sa, -za, -pa, -fa, -cha, -ša
        /// typically have no epenthesis.
        /// </summary>
        public bool? TriggersEpenthesisAsC2 { get; init; }
    }
}
