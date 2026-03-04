using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface IPronounDataProvider
    {
        public Dictionary<string, PronounData> GetPronouns();
    }
}
