using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface IPrepositionDataProvider
    {
        Dictionary<string, PrepositionData> GetPrepositions();
    }
}
