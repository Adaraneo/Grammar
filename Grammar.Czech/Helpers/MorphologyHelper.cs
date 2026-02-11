using Grammar.Core.Models;
using Grammar.Core.Enums;
using Grammar.Czech.Models;
using Grammar.Czech.Services;

namespace Grammar.Czech.Helpers
{
    public static class MorphologyHelper
    {
        public static string ApplyFormEnding(string stem, string ending)
        {
            if (IsEnding(ending))
            {
                return stem + ending.Replace("-", "");
            }
            else
            {
                return ending;
            }
        }

        public static bool EndsWithTwoConsonants(string stem)
        {
            if (stem.Length < 2)
            {
                return false;
            }

            var last = stem[^1];
            var secondLast = stem[^2];
            return IsConsonant(secondLast) && IsConsonant(last);
        }

        public static bool EndsWithVowelConsonantVowelConsonant(string lemma)
        {
            if (lemma.Length < 4)
            {
                return false;
            }

            var vowel = lemma[^4];
            var consonant = lemma[^3];
            var lastVowel = lemma[^2];
            var lastConsonant = lemma[^1];
            return !IsConsonant(vowel) && IsConsonant(consonant) && !IsConsonant(lastVowel) && IsConsonant(lastConsonant);
        }

        public static bool IsConsonant(char c)
        {
            return !"aeiouáéíóúýě".Contains(char.ToLower(c)); // české samohlásky
        }

        public static bool IsEnding(string ending) => ending.Contains("-");
    }
}