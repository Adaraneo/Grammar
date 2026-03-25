using Grammar.Core.Enums;

namespace Grammar.Core.Models.Derivation
{
    /// <summary>
    /// Represents a language-agnostic link from a root to one of its derived lexemes.
    /// Language-specific subclasses (e.g., <c>CzechDerivationLink</c>) extend this record
    /// with pattern, gender, and phonological alternation metadata.
    /// </summary>
    public record DerivationLink
    {
        /// <summary>Gets the lemma of the derived word (e.g., "mladík").</summary>
        public string Lemma { get; init; } = string.Empty;

        /// <summary>Gets the derivational suffix added to the root (e.g., "ík").</summary>
        public string Suffix { get; init; } = string.Empty;

        /// <summary>Gets the part of speech of the derived word.</summary>
        public WordCategory PartOfSpeech { get; init; }

        /// <summary>Gets the morphological relationship expressed by this derivation.</summary>
        public DerivationType Type { get; init; }
    }
}
