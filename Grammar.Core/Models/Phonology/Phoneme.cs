using Grammar.Core.Enums.PhonologicalFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Models.Phonology
{
    public record Phoneme
    {
        public required string Symbol { get; init; }
        public ArticulationPlace? Place { get; init; }
        public ArticulationManner? Manner { get; init; }
        public Voicing? Voicing { get; init; }

        public VowelBackness? Backness { get; init; }
        public VowelHeight? Height { get; init; }
        public bool? IsRounded { get; init; }

        public string? PalatalizeTo { get; init; }
        public string? VoicedCounterpart { get; init; }
        public string? VoicelessCounterpart { get; init; }
    }
}
