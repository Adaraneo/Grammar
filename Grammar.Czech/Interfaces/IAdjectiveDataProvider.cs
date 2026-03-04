using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface IAdjectiveDataProvider
    {
        Dictionary<string, AdjectivePattern> GetPatterns();
    }
}
