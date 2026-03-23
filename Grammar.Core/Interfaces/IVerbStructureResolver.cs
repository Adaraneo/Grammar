using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface IVerbStructureResolver<TWord> where TWord : IWordRequest
    {
        VerbStructure AnalyzeVerbStructure(TWord wordRequest);
    }
}
