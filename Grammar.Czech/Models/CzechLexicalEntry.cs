using Grammar.Core.Enums;
using Grammar.Core.Models.Valency;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Extends <see cref="LexicalEntry"/> with Czech-specific morphological metadata.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Properties in this record are specific to Czech or other Slavic languages
    /// and must not be placed in the language-agnostic <see cref="LexicalEntry"/>.
    /// </para>
    /// <para>
    /// When an entry exists in the lexicon, inflection services use its data directly
    /// instead of falling back to guess heuristics.
    /// </para>
    /// </remarks>
    public sealed record CzechLexicalEntry : LexicalEntry
    {
        /// <summary>
        /// Gets a value indicating whether the lemma is animate (e.g., <c>student</c>, <c>pes</c>),
        /// or <c>null</c> if not applicable.
        /// </summary>
        public bool? IsAnimate { get; init; }

        /// <summary>
        /// Gets a value indicating whether the lemma contains a mobile vowel (pohyblivé e),
        /// or <c>null</c> if not applicable.
        /// </summary>
        /// <example>
        /// <c>pes</c> → <c>psa</c> (mobile vowel present),
        /// <c>student</c> → <c>studenta</c> (no mobile vowel).
        /// </example>
        public bool? HasMobileVowel { get; init; }

        /// <summary>
        /// Gets a value indicating whether the genitive plural form shortens the stem vowel,
        /// or <c>null</c> if not applicable.
        /// </summary>
        /// <example>
        /// <c>kráva</c> → <c>krav</c> (shortening present),
        /// <c>sféra</c> → <c>sfér</c> (no shortening).
        /// </example>
        public bool? HasGenitivePluralShortening { get; init; }

        /// <summary>
        /// Gets the verbal aspect of the lemma, or <c>null</c> for non-verbs.
        /// </summary>
        public VerbAspect? Aspect { get; init; }

        /// <summary>
        /// Gets the lemma of the aspect counterpart, or <c>null</c> if none exists or is unknown.
        /// </summary>
        /// <remarks>
        /// Required for correct future-tense generation:
        /// imperfective future uses the periphrastic form (<c>"budu dělat"</c>),
        /// perfective future uses the simple present form (<c>"udělám"</c>).
        /// </remarks>
        public string? AspectCounterpart { get; init; }
    }
}
