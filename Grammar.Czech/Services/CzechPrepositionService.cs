using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    /// <summary>
    /// Provides Czech preposition case government and semantic group lookup operations.
    /// </summary>
    public class CzechPrepositionService : ICzechPrepositionService
    {
        private readonly Dictionary<string, PrepositionData> _prepositions;

        /// <summary>
        /// Initializes a new instance of the <see cref="CzechPrepositionService"/> type.
        /// </summary>
        public CzechPrepositionService(IPrepositionDataProvider dataProvider)
        {
            _prepositions = dataProvider.GetPrepositions();
        }

        /// <summary>
        /// Gets the grammatical cases allowed by the supplied preposition.
        /// </summary>
        /// <param name="preposition">The preposition text to look up.</param>
        /// <returns>The grammatical cases governed by the preposition, or an empty sequence when it is unknown.</returns>
        public IEnumerable<Case> GetAllowedCases(string preposition)
        {
            if (_prepositions.TryGetValue(preposition, out var data))
            {
                return data.Variants.Select(v => v.Case).Distinct();
            }

            return Enumerable.Empty<Case>();
        }

        /// <summary>
        /// Gets the semantic group for a preposition and governed case.
        /// </summary>
        /// <param name="preposition">The preposition text to look up.</param>
        /// <param name="case">The grammatical case governed by the preposition.</param>
        /// <returns>The semantic group for the matching preposition variant, or <see langword="null"/> when no variant matches.</returns>
        public PrepositionSemanticGroup? GetSemanticGroup(string preposition, Case @case)
        {
            if (_prepositions.TryGetValue(preposition, out var data))
            {
                return data.Variants.FirstOrDefault(v => v.Case == @case)?.SemanticGroup;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the supplied preposition can govern the requested case.
        /// </summary>
        /// <param name="preposition">The preposition text to look up.</param>
        /// <param name="case">The grammatical case governed by the preposition.</param>
        /// <returns><see langword="true"/> when the case is allowed for the preposition; otherwise, <see langword="false"/>.</returns>
        public bool IsAllowed(string preposition, Case @case)
        {
            return GetAllowedCases(preposition).Contains(@case);
        }
    }
}
