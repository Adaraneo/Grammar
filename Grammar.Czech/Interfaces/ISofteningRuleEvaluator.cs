using Grammar.Core.Interfaces;

namespace Grammar.Czech.Interfaces
{
    public interface ISofteningRuleEvaluator<TWord> where TWord : IWordRequest
    {
        bool ShouldApplySoftening(TWord wordRequest);

        string? GetEndingTransformation(TWord wordRequest);
    }
}
