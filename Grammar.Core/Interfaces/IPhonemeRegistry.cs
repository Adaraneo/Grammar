using Grammar.Core.Models.Phonology;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for Phoneme Registry.
    /// </summary>
    public interface IPhonemeRegistry
    {
        /// <summary>
        /// Gets the phoneme matching the supplied symbol.
        /// </summary>
        /// <param name="symbol">The phoneme symbol to look up.</param>
        /// <returns>The matching phoneme, or <see langword="null"/> when the symbol is not registered.</returns>
        Phoneme? Get(string symbol);

        /// <summary>
        /// Gets the phoneme matching the supplied symbol.
        /// </summary>
        /// <param name="symbol">The phoneme symbol to look up.</param>
        /// <returns>The matching phoneme, or <see langword="null"/> when the symbol is not registered.</returns>
        Phoneme? Get(char symbol) => Get(symbol.ToString());

        /// <summary>
        /// Determines whether the supplied character is a vowel.
        /// </summary>
        /// <param name="c">The character to classify.</param>
        /// <returns><see langword="true"/> when the character is a vowel; otherwise, <see langword="false"/>.</returns>
        bool IsVowel(char c);

        /// <summary>
        /// Determines whether the supplied character is a consonant.
        /// </summary>
        /// <param name="c">The character to classify.</param>
        /// <returns><see langword="true"/> when the character is a consonant; otherwise, <see langword="false"/>.</returns>
        bool IsConsonant(char c);

        /// <summary>
        /// Determines whether the supplied character is a front vowel.
        /// </summary>
        /// <param name="c">The character to classify.</param>
        /// <returns><see langword="true"/> when the character is a front vowel; otherwise, <see langword="false"/>.</returns>
        bool IsFrontVowel(char c);

        /// <summary>
        /// Gets all phonemes registered by the Czech phoneme registry.
        /// </summary>
        IReadOnlyCollection<Phoneme> AllPhonemes { get; }
    }
}
