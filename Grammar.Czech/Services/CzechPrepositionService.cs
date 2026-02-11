using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechPrepositionService : ICzechPrepositionService
    {
        private readonly Dictionary<string, PrepositionData> _prepositions;

        public CzechPrepositionService(IPrepositionDataProvider dataProvider)
        {
            _prepositions = dataProvider.GetPrepositions();
        }

        public IEnumerable<Case> GetAllowedCases(string preposition)
        {
            if (_prepositions.TryGetValue(preposition, out var data))
            {
                return data.Variants.Select(v => v.Case).Distinct();
            }

            return Enumerable.Empty<Case>();
        }

        public PrepositionSemanticGroup? GetSemanticGroup(string preposition, Case @case)
        {
            if (_prepositions.TryGetValue(preposition, out var data))
            {
                return data.Variants.FirstOrDefault(v => v.Case == @case)?.SemanticGroup;
            }

            return null;
        }

        public bool IsAllowed(string preposition, Case @case)
        {
            return GetAllowedCases(preposition).Contains(@case);
        }
    }
}
