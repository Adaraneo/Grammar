using Grammar.Core.Enums;

namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Stores the morphological identity of a single lemma.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>LexicalEntry</c> is the per-lemma metadata layer that eliminates the need for
    /// guess heuristics (<c>GuessGenderAndPattern</c>, <c>GuessVerbAspect</c>).
    /// When an entry exists, the inflection services use its data directly.
    /// Guess heuristics serve only as a fallback for lemmata without a registered entry.
    /// </para>
    /// <para>
    /// One lemma has exactly one <c>LexicalEntry</c>; one lemma may have
    /// multiple <see cref="ValencyFrame"/> instances (see <c>IValencyProvider.GetFrames</c>).
    /// Do not merge these two concerns into a single record.
    /// </para>
    /// </remarks>
    public sealed record LexicalEntry
    {
        /// <summary>Gets the lemma (dictionary form) of the word.</summary>
        public string Lemma { get; init; } = string.Empty;

        /// <summary>Gets the word category (part of speech).</summary>
        public WordCategory Category { get; init; }

        /// <summary>Gets the grammatical gender, or <c>null</c> for verbs and indeclinable words.</summary>
        public Gender? Gender { get; init; }

        /// <summary>
        /// Gets the inflectional pattern key (e.g., "pán", "žena", "trida5"),
        /// or <c>null</c> if the pattern must be guessed.
        /// </summary>
        public string? Pattern { get; init; }

        /// <summary>Gets a value indicating whether the lemma is animate, or <c>null</c> if not applicable.</summary>
        public bool? IsAnimate { get; init; }

        /// <summary>Gets a value indicating whether the lemma has a mobile vowel (e.g., "pes").</summary>
        public bool? HasMobileVowel { get; init; }

        /// <summary>Gets the verbal aspect, or <c>null</c> for non-verbs.</summary>
        public VerbAspect? Aspect { get; init; }

        /// <summary>
        /// Gets the lemma of the aspect counterpart, or <c>null</c> if none exists or is unknown.
        /// Required for correct future-tense generation:
        /// imperfective future uses the periphrastic form ("budu dělat"),
        /// perfective future uses the simple present form ("udělám").
        /// </summary>
        public string? AspectCounterpart { get; init; }
    }
}
