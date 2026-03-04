using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface IVerbInflectionService<TWord> where TWord : IWordRequest
    {
        WordForm GetBasicForm(TWord wordRequest);
    }
}
