using Grammar.Core.Enums;
using Grammar.Core.Models.Derivation;
using Grammar.Czech.Enums;

namespace Grammar.Czech.Models.Derivation
{
    /// <summary>
    /// Extends <see cref="DerivationLink"/> with Czech-specific inflectional metadata
    /// needed to construct a <c>CzechWordRequest</c> for the derived lemma.
    /// </summary>
    public sealed record CzechDerivationLink : DerivationLink
    {
        /// <summary>
        /// Gets the inflectional pattern key for the derived lemma (e.g., "pán", "žena", "stavení").
        /// Must match a key in <c>patterns.json</c>.
        /// </summary>
        public string? Pattern { get; init; }

        /// <summary>Gets the grammatical gender of the derived lemma.</summary>
        public Gender? Gender { get; init; }

        /// <summary>Gets a value indicating whether the derived lemma is animate.</summary>
        public bool? IsAnimate { get; init; }

        /// <summary>
        /// Gets the ordered list of phonological alternations applied to the root
        /// before the derivational suffix is attached.
        /// Each alternation is resolved via <c>IPhonemeRegistry</c>.
        /// </summary>
        public IReadOnlyList<CzechDerivationAlternation> Alternations { get; init; } = [];
    }
}
