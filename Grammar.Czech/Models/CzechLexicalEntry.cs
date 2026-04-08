using Grammar.Core.Enums;
using Grammar.Core.Models.Valency;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents czech lexical entry.
    /// </summary>
    public sealed record CzechLexicalEntry : LexicalEntry
    {
        /// <summary>
        /// Gets or sets a value indicating whether the noun is animate.
        /// </summary>
        public bool? IsAnimate { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether mobile vowel alternation applies.
        /// </summary>
        public bool? HasMobileVowel { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether genitive plural shortening applies.
        /// </summary>
        public bool? HasGenitivePluralShortening { get; init; }

        /// <summary>
        /// Gets or sets the requested or resolved verb aspect.
        /// </summary>
        public VerbAspect? Aspect { get; init; }

        /// <summary>
        /// Gets or sets aspect Counterpart.
        /// </summary>
        public string? AspectCounterpart { get; init; }
    }
}
