namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines operations for phonology behavior.
    /// </summary>
    public interface IPhonologyService<TWord> where TWord : IWordRequest
    {
        /// <summary>
        /// Applies softening.
        /// </summary>
        /// <param name="word">The word or stem to soften.</param>
        /// <returns>The word or stem after softening has been applied.</returns>
        string ApplySoftening(string word);

        /// <summary>
        /// Reverts consonant softening on the supplied word or stem when possible.
        /// </summary>
        /// <param name="word">The word or stem to restore.</param>
        /// <returns>The word or stem after softening has been reverted when a reverse mapping exists.</returns>
        string RevertSoftening(string word);

        /// <summary>
        /// Removes a mobile vowel from the supplied stem when the morphology rule requires it.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <param name="hasMobileVowel">True when the stem is known to contain a mobile vowel; otherwise, false.</param>
        /// <returns>The stem with its mobile vowel removed when applicable.</returns>
        string RemoveMobileE(string stem, bool hasMobileVowel);

        /// <summary>
        /// Inserts a mobile vowel into the supplied stem when the morphology rule requires it.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <param name="position">The zero-based position where the mobile vowel should be inserted.</param>
        /// <returns>The stem with the mobile vowel inserted at the requested position.</returns>
        string InsertMobileE(string stem, int position);

        /// <summary>
        /// Applies epenthesis.
        /// </summary>
        /// <param name="needsEpenthesis">True when epenthesis should be applied; otherwise, false.</param>
        /// <param name="stem">The stem to transform.</param>
        /// <param name="derivationSuffix">The derivational suffix that may require epenthesis.</param>
        /// <returns>The stem combined with the suffix, including epenthesis when requested.</returns>
        string ApplyEpenthesis(bool needsEpenthesis, string stem, string derivationSuffix);

        /// <summary>
        /// Shortens the final long vowel in the supplied stem when possible.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <returns>The stem with the final long vowel shortened when a short counterpart exists.</returns>
        string ShortenVowel(string stem);

        /// <summary>
        /// Lengthens the final short vowel in the supplied stem when possible.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <returns>The stem with the final short vowel lengthened when a long counterpart exists.</returns>
        string LengthenVowel(string stem);
    }
}
