using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface IVerbDataProvider
    {
        Dictionary<string, VerbPattern> GetPatterns();

        Dictionary<string, VerbPattern> GetIrregulars();
    }
}
