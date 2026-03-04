using Grammar.Core.Models.Phonology;

namespace Grammar.Core.Extensions
{
    public static class PhonemeExtensions
    {
        public static bool IsVowel(this Phoneme phoneme) => phoneme.Backness is not null;

        public static bool IsConsonant(this Phoneme phoneme) => phoneme.Place is not null;

        public static bool IsDiphthong(this Phoneme phoneme) => phoneme.IsVowel() && phoneme.Symbol.Length > 1;
    }
}
