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

        public string ApplySoftening(string stem)
        {
            if (stem is null)
                throw new ArgumentNullException(nameof(stem));

            if (stem.EndsWith("ch"))
                return stem[..^2] + "š";

            var last = stem[^1..];
            return softMap.TryGetValue(last, out var softened)
                ? stem[..^1] + softened
                : stem;
        }

        public string RevertSoftening(string stem)
        {
            if (stem is null)
                throw new ArgumentNullException(nameof(stem));

            if (stem.EndsWith("š"))
                return stem[..^1] + "ch";

            var last = stem[^1..];
            return reverseMap.TryGetValue(last, out var original)
                ? stem[..^1] + original
                : stem;
        }
    }
}
