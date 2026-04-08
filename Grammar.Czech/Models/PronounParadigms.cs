using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    namespace Grammar.Czech.Models
    {
        /// <summary>
        /// Represents pronoun paradigm.
        /// </summary>
        public sealed record PronounParadigm
        {
            /// <summary>
            /// Gets the forms grouped by number, gender slot, and case.
            /// </summary>
            public Dictionary<Number, Dictionary<GenderSlot, Dictionary<Case, string>>> Slots { get; init; } = new();
        }

        /// <summary>
        /// Specifies gender Slot values.
        /// </summary>
        public enum GenderSlot
        {
            MasculineAnimate,
            MasculineInanimate,
            Feminine,
            Neuter,
            Other   // pro plurál kde fem/neutr/inan sdílejí tvary
        }
    }
}
