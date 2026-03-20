using Grammar.Czech.Interfaces;

namespace Grammar.Czech.Services
{
    public class CzechPrefixService : ICzechPrefixService
    {
        private readonly List<string> negationPrefixes;
        private readonly List<string> perfectivePrefixes;
        private readonly List<string> allVerbalPrefixes;

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
            allVerbalPrefixes = prefixesDict.Values
                .SelectMany(p => p)
                .Distinct()
                .OrderByDescending(p => p.Length)
                .ToList();
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

        public string? FindVerbalPrefix(string lemma)
        {
            return allVerbalPrefixes.FirstOrDefault(p => lemma.StartsWith(p) && lemma.Length > p.Length + 1);
        }
    }
}
