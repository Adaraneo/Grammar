using Grammar.Core.Enums.PhonologicalFeatures;

namespace Grammar.Core.Models.Phonology
{
    public record Phoneme
    {
        public required string Symbol { get; init; }

        #region Consonants

        public ArticulationPlace? Place { get; init; }
        public ArticulationManner? Manner { get; init; }
        public Voicing? Voicing { get; init; }

        #endregion Consonants

        #region Vowels

        public VowelBackness? Backness { get; init; }
        public VowelHeight? Height { get; init; }
        public bool? IsRounded { get; init; }

        #endregion Vowels

        #region Palatalization

        public string? PalatalizeTo { get; init; }
        public string? VoicedCounterpart { get; init; }
        public string? VoicelessCounterpart { get; init; }
        public string? ShortCounterpart { get; init; }
        public string? LongCounterpart { get; init; }

        #endregion Palatalization
    }
}
