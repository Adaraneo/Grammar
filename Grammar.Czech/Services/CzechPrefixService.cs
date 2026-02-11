using System.Text.Json;
using Grammar.Czech.Interfaces;

namespace Grammar.Czech.Services
{
    public class CzechPrefixService : ICzechPrefixService
    {
        private readonly List<string> negationPrefixes;
        private readonly List<string> perfectivePrefixes;

        public CzechPrefixService(IPrefixDataProvider dataProvider)
        {
            var prefixesDict = dataProvider.GetPrefixes();
            var containsPrefixes = prefixesDict.ContainsKey("perfective") && prefixesDict.ContainsKey("negation");
            if (!containsPrefixes)
            {
                throw new Exception("No accurate prefixes found!");
            }

            perfectivePrefixes = prefixesDict["perfective"];
            negationPrefixes = prefixesDict["negation"];
        }

        public string FindPerfectivePrefix(string lemma)
        {
            return perfectivePrefixes
            .OrderByDescending(p => p.Length)
            .FirstOrDefault(p => lemma.StartsWith(p) && lemma.Length > p.Length + 1)!;
        }

        public string GetNegativePrefix()
        {
            return negationPrefixes[0];
        }

        public bool HasPerfectivePrefix(string lemma)
        {
            return FindPerfectivePrefix(lemma) != null;
        }
    }
}