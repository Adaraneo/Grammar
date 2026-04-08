using Grammar.Core.Models.Phonology;

namespace Grammar.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for phonological feature checks.
    /// </summary>
    public static class PhonemeExtensions
    {
        /// <summary>
        /// Determines whether is Vowel.
        /// </summary>
        /// <param name="phoneme">The phoneme to inspect.</param>
        /// <returns>True when the condition is met; otherwise, false.</returns>
        public static bool IsVowel(this Phoneme phoneme) => phoneme.Backness is not null;

        /// <summary>
        /// Determines whether is Consonant.
        /// </summary>
        /// <param name="phoneme">The phoneme to inspect.</param>
        /// <returns>True when the condition is met; otherwise, false.</returns>
        public static bool IsConsonant(this Phoneme phoneme) => phoneme.Place is not null;

        /// <summary>
        /// Determines whether is Diphthong.
        /// </summary>
        /// <param name="phoneme">The phoneme to inspect.</param>
        /// <returns>True when the condition is met; otherwise, false.</returns>
        public static bool IsDiphthong(this Phoneme phoneme) => phoneme.IsVowel() && phoneme.Symbol.Length > 1;
    }
}
