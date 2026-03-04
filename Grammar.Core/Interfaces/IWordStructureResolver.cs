using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface IWordStructureResolver<TWord> where TWord : IWordRequest
    {
        WordStructure AnalyzeStructure(TWord wordRequest);
    }
}
