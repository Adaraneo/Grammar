using Grammar.Core.Enums;

namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Stores the morphological identity of a single lemma.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <c>LexicalEntry</c> is the language-agnostic per-lemma metadata layer.
    /// It contains only properties applicable to any natural language.
    /// Language-specific properties (e.g. verbal aspect, animacy, mobile vowel)
    /// belong in a language-specific subtype such as <c>CzechLexicalEntry</c>.
    /// </para>
    /// <para>
    /// One lemma has exactly one <c>LexicalEntry</c>; one lemma may have
    /// multiple <see cref="ValencyFrame"/> instances (see <c>IValencyProvider.GetFrames</c>).
    /// Do not merge these two concerns into a single record.
    /// </para>
    /// </remarks>
    public record LexicalEntry
    {
        /// <summary>Gets the lemma (dictionary form) of the word.</summary>
        public string Lemma { get; init; } = string.Empty;

        /// <summary>Gets the word category (part of speech).</summary>
        public WordCategory Category { get; init; }

        /// <summary>Gets the grammatical gender, or <c>null</c> for verbs and indeclinable words.</summary>
        public Gender? Gender { get; init; }

        /// <summary>
        /// Gets the inflectional pattern key (e.g., <c>"pán"</c>, <c>"žena"</c>, <c>"trida5"</c>),
        /// or <c>null</c> if the pattern must be guessed.
        /// </summary>
        public string? Pattern { get; init; }
    }
}
