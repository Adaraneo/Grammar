namespace Grammar.Czech.Interfaces
{
    public interface ICzechPrefixService
    {
        string FindPerfectivePrefix(string lemma);

        string GetNegativePrefix();

        bool HasPerfectivePrefix(string lemma);
    }
}
