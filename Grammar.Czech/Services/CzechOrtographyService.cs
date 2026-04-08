using Grammar.Core.Enums.PhonologicalFeatures;
using Grammar.Core.Interfaces;
using Grammar.Czech.Interfaces;

namespace Grammar.Czech.Services
{
    /// <summary>
    /// Provides Czech orthography adjustments for endings and jotation.
    /// </summary>
    public class CzechOrtographyService : ICzechOrtographyService
    {
        private readonly IPhonemeRegistry _registry;

        /// <summary>
        /// Initializes a new instance of the <see cref="CzechOrtographyService"/> type.
        /// </summary>
        public CzechOrtographyService(IPhonemeRegistry registry)
        {
            this._registry = registry;
        }

        /// <summary>
        /// Applies Czech orthographic changes caused by jotation.
        /// </summary>
        /// <param name="ending">The ending used to choose the morphology rule.</param>
        /// <returns>The ending with initial e changed to e-with-caron when jotation applies.</returns>
        public string ApplyJotationOrthography(string ending)
        {
            var normalized = ending.TrimStart('-');
            var dashPrefix = ending.Length - normalized.Length;

            if (!normalized.StartsWith('e'))
                return ending;

            return ending[..dashPrefix] + 'ě' + normalized[1..];
        }

        /// <summary>
        /// Normalizes ending spelling against the final stem consonant.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <param name="ending">The ending used to choose the morphology rule.</param>
        /// <returns>The normalized ending spelling for the supplied stem.</returns>
        public string NormalizeEndingOrthography(string stem, string ending)
        {
            if (string.IsNullOrEmpty(stem) || string.IsNullOrEmpty(ending))
                return ending;

            var normalizedEnding = ending.TrimStart('-');
            var dashPrefix = ending.Length - normalizedEnding.Length;

            // Pouze ě→e reverze — e→ě patří výhradně do JSON dat
            if (!normalizedEnding.StartsWith('ě'))
                return ending;

            var phoneme = _registry.Get(stem[^1..]);

            var isDTN = phoneme?.Place == ArticulationPlace.Alveolar
                && (phoneme.Manner == ArticulationManner.Nasal
                    || phoneme.Manner == ArticulationManner.Plosive);

            // Bilabial pouze — Labiodental (v, f) sem nepatří, řeší jotace
            var isLabial = phoneme?.Place == ArticulationPlace.Bilabial;

            // ě má smysl jen po DTN (ňe/ďe/ťe) a labiálách (jotace)
            // Kdekoliv jinde je ortografická chyba → normalizuj na e
            if (!isDTN && !isLabial)
                return ending[..dashPrefix] + 'e' + normalizedEnding[1..];

            return ending;
        }
    }
}
