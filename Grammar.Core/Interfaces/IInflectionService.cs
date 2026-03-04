using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface IInflectionService<TWord> where TWord : IWordRequest
    {
        WordForm GetForm(TWord wordRequest);
    }
}
