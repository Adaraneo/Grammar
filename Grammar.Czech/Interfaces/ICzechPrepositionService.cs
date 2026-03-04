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
