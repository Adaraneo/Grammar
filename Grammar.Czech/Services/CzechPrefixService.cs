using Grammar.Czech.Interfaces;

namespace Grammar.Czech.Services
{
    /// <summary>
    /// Provides czech prefix operations.
    /// </summary>
    public class CzechPrefixService : ICzechPrefixService
    {
        private readonly List<string> negationPrefixes;
        private readonly List<string> perfectivePrefixes;
        private readonly List<string> allVerbalPrefixes;

        /// <summary>
        /// Initializes a new instance of the <see cref="CzechPrefixService"/> type.
        /// </summary>
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

        /// <summary>
        /// Finds the longest perfective prefix at the beginning of the supplied lemma.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <returns>The matching perfective prefix, or <see langword="null"/> when none is found.</returns>
        public string FindPerfectivePrefix(string lemma)
        {
            return perfectivePrefixes
            .OrderByDescending(p => p.Length)
            .FirstOrDefault(p => lemma.StartsWith(p) && lemma.Length > p.Length + 1)!;
        }

        /// <summary>
        /// Gets the negative prefix used for Czech negation.
        /// </summary>
        /// <returns>The Czech negative prefix.</returns>
        public string GetNegativePrefix()
        {
            return negationPrefixes[0];
        }

        /// <summary>
        /// Determines whether the supplied lemma starts with a known perfective prefix.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <returns><see langword="true"/> when the lemma has a perfective prefix; otherwise, <see langword="false"/>.</returns>
        public bool HasPerfectivePrefix(string lemma)
        {
            return FindPerfectivePrefix(lemma) != null;
        }

        /// <summary>
        /// Finds the first known verbal prefix at the beginning of the supplied lemma.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <returns>The matching verbal prefix, or <see langword="null"/> when none is found.</returns>
        public string? FindVerbalPrefix(string lemma)
        {
            return allVerbalPrefixes.FirstOrDefault(p => lemma.StartsWith(p) && lemma.Length > p.Length + 1);
        }
    }
}
