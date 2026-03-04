using Grammar.Core.Interfaces;

namespace Grammar.Czech.Interfaces
{
    public interface IEpenthesisRuleEvaluator<TWord> where TWord : IWordRequest
    {
        bool ShouldApplyEpenthesis(string stem, string derivationSuffix, TWord wordRequest);
    }
}
