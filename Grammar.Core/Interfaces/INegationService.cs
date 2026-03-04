using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface INegationService<TWord> where TWord : IWordRequest
    {
        WordForm ApplyNegation(TWord word, string baseForm);
    }
}
