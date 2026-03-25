namespace Grammar.Czech.Enums
{
    /// <summary>
    /// Specifies a phonological alternation applied to the root when building
    /// a derived Czech lemma from a root entry.
    /// </summary>
    /// <remarks>
    /// Each alternation is resolved via <c>IPhonemeRegistry</c> — never by hard-coded
    /// character comparisons. For example, <see cref="LengthenRoot"/> uses
    /// <c>Phoneme.LongCounterpart</c> to determine the lengthened vowel.
    /// </remarks>
    public enum CzechDerivationAlternation
    {
        /// <summary>No phonological alternation — root is used as-is.</summary>
        None,

        /// <summary>
        /// Lengthens the last root vowel (e.g., "mlad" → "mládí").
        /// Uses <c>Phoneme.LongCounterpart</c> from <c>IPhonemeRegistry</c>.
        /// </summary>
        LengthenRoot,

        /// <summary>
        /// Shortens the last root vowel.
        /// Uses <c>Phoneme.ShortCounterpart</c> from <c>IPhonemeRegistry</c>.
        /// </summary>
        ShortenRoot,

        /// <summary>
        /// Applies palatalization to the final root consonant
        /// (e.g., "matk" → "matč" for "matčin").
        /// Uses <c>Phoneme.PalatalizeTo</c> from <c>IPhonemeRegistry</c>.
        /// </summary>
        PalatalizeStem,

        /// <summary>
        /// Removes the mobile vowel from the root before attaching the suffix
        /// (e.g., "pes" → "ps" before "-í").
        /// </summary>
        DropMobileVowel,
    }
}
