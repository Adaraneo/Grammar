using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface INounDataProvider
    {
        Dictionary<string, NounPattern> GetPatterns();

        Dictionary<string, NounPattern> GetIrregulars();

        Dictionary<string, NounPattern> GetPropers();
    }
}
