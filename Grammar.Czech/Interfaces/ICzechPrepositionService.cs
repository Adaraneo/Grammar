using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;

namespace Grammar.Czech.Interfaces
{
    public interface ICzechPrepositionService
    {
        IEnumerable<Case> GetAllowedCases(string preposition);
        PrepositionSemanticGroup? GetSemanticGroup(string preposition, Case kase);
        bool IsAllowed(string preposition, Case kase);
    }

}
