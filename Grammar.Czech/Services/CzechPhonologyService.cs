using Grammar.Core.Interfaces;
using Grammar.Czech.Helpers;
using Grammar.Czech.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grammar.Czech.Services
{
    public class CzechPhonologyService : IPhonologyService<CzechWordRequest>
    {
        // Blacklist slov, kde se epentheze NEPOUŽÍVÁ (historické výjimky)
        private static readonly HashSet<string> epenthesisBlacklist = new()
        {
            "knih",  // kniha → knih (ne *knihek)
            "noh",   // noha → noh (ne *nohek)
            "much",  // moucha → much (ne *muchek)
            "vrb",   // vrba → vrb (ne *vrbek)
        };

        // Kmeny, které VŽDY potřebují epenthezi
        private static readonly HashSet<string> epenthesisWhitelist = new()
        {
            "ok",    // okno → oken
            "slovíč", // slovíčko → slovíček
        };

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

        public bool HasMobileVowel(string stem)
        {
            if (string.IsNullOrEmpty(stem) || stem.Length < 2)
            {
                return false;
            }

            var lastTwo = stem[^2..];
            var vowel = lastTwo[0];
            var consonant = lastTwo[1];

            if (vowel != 'e' && vowel != 'ě')
            {
                return false;
            }

            return MorphologyHelper.IsConsonant(consonant);
        }

        public string InsertMobileVowel(string stem, int position)
        {
            if (position < 0 || position > stem.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be within the bounds of the stem.");
            }

            return stem.Insert(position, "e");
        }

        public string RemoveMobileVowel(string stem)
        {
            if (!HasMobileVowel(stem))
            {
                return stem;
            }

            return stem[..^2] + stem[^1];
        }

        public bool NeedsEpenthesis(string stem, string suffix, CzechWordRequest request)
        {
            if (string.IsNullOrEmpty(stem) || string.IsNullOrEmpty(suffix))
            {
                return false;
            }

            if (!MorphologyHelper.IsConsonant(suffix[0]))
            {
                return false;
            }

            if (!MorphologyHelper.IsConsonant(stem[^1]))
            {
                return false;
            }

            if (epenthesisWhitelist.Contains(stem))
            {
                return true;
            }

            if (epenthesisBlacklist.Contains(stem))
            {
                return false;
            }

            return EvaluateEpenthesisRules(stem, suffix, request);
        }

        private bool EvaluateEpenthesisRules(string stem, string suffix, CzechWordRequest request)
        {
            if (request.WordCategory == Core.Enums.WordCategory.Noun &&
                request.Case == Core.Enums.Case.Genitive &&
                request.Number == Core.Enums.Number.Plural &&
                (suffix == "k" || suffix == "g"))
            {
                if (!stem.EndsWith(suffix))
                {
                    return true;
                }
            }

            if (request.WordCategory == Core.Enums.WordCategory.Noun &&
                request.Case == Core.Enums.Case.Genitive &&
                request.Number == Core.Enums.Number.Plural &&
                request.Gender == Core.Enums.Gender.Neuter &&
                suffix == "n")
            {
                return true;
            }

            return false;
        }

        public string ApplyEpenthesis(string stem, string suffix, CzechWordRequest request)
        {
            if (NeedsEpenthesis(stem, suffix, request))
            {
                return stem + "e" + suffix;
            }

            return stem + suffix;
        }
    }
}
