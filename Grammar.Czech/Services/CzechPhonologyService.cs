using Grammar.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Grammar.Czech.Services
{
    public class CzechPhonologyService : IPhonologyService
    {
        private static readonly Dictionary<string, string> softMap = new()
        {
            { "k", "c" },
            { "h", "z" },
            { "d", "ď" },
            { "t", "ť" },
            { "n", "ň" },
            { "c", "č" },
            //{ "ch", "š" } // speciální případ
        };

        private static readonly Dictionary<string, string> reverseMap =
            softMap.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        public string ApplySoftening(string word)
        {
            if (word.EndsWith("ch"))
                return word[..^2] + "š";

            var last = word[^1..];
            return softMap.TryGetValue(last, out var softened)
                ? word[..^1] + softened
                : word;
        }

        public string RevertSoftening(string word)
        {
            if (word.EndsWith("š"))
                return word[..^1] + "ch";

            var last = word[^1..];
            return reverseMap.TryGetValue(last, out var original)
                ? word[..^1] + original
                : word;
        }
    }
}
