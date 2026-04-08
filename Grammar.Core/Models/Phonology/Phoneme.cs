using Grammar.Core.Enums.PhonologicalFeatures;

namespace Grammar.Core.Models.Phonology
{
    /// <summary>
    /// Represents phonological features of a single phoneme.
    /// </summary>
    public record Phoneme
    {
        /// <summary>
        /// Gets or sets symbol.
        /// </summary>
        public required string Symbol { get; init; }

        #region Consonants

        /// <summary>
        /// Gets or sets place.
        /// </summary>
        public ArticulationPlace? Place { get; init; }
        /// <summary>
        /// Gets or sets manner.
        /// </summary>
        public ArticulationManner? Manner { get; init; }
        /// <summary>
        /// Gets or sets voicing.
        /// </summary>
        public Voicing? Voicing { get; init; }

        /// <summary>
        /// Gets or sets assimilates Place Before.
        /// </summary>
        public ArticulationPlace? AssimilatesPlaceBefore { get; init; }

        #endregion Consonants

        #region Vowels

        /// <summary>
        /// Gets or sets backness.
        /// </summary>
        public VowelBackness? Backness { get; init; }
        /// <summary>
        /// Gets or sets height.
        /// </summary>
        public VowelHeight? Height { get; init; }
        /// <summary>
        /// Gets or sets is Rounded.
        /// </summary>
        public bool? IsRounded { get; init; }

        #endregion Vowels

        #region Alternartions

        /// <summary>
        /// Gets or sets palatalize To.
        /// </summary>
        public string? PalatalizeTo { get; init; }
        /// <summary>
        /// Gets or sets voiced Counterpart.
        /// </summary>
        public string? VoicedCounterpart { get; init; }
        /// <summary>
        /// Gets or sets voiceless Counterpart.
        /// </summary>
        public string? VoicelessCounterpart { get; init; }
        /// <summary>
        /// Gets or sets short Counterpart.
        /// </summary>
        public string? ShortCounterpart { get; init; }
        /// <summary>
        /// Gets or sets long Counterpart.
        /// </summary>
        public string? LongCounterpart { get; init; }

        #endregion Alternartions
    }
}
