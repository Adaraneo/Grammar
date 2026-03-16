using Grammar.Core.Interfaces;
using Grammar.Czech.Enums.Phonology;

namespace Grammar.Czech.Interfaces
{
    public interface ISofteningRuleEvaluator<TWord> where TWord : IWordRequest
    {
        bool ShouldApplySoftening(TWord wordRequest, out PalatalizationContext context);

        string? GetEndingTransformation(TWord wordRequest, out bool applied);
    }
}
