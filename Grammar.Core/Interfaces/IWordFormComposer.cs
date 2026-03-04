using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface IWordFormComposer<TWord> where TWord : IWordRequest
    {
        WordForm GetFullForm(TWord request);
    }
}
