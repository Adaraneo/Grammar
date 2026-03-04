using Grammar.Core.Models.Phonology;

namespace Grammar.Core.Interfaces
{
    public interface IPhonemeRegistry
    {
        Phoneme? Get(string symbol);

        Phoneme? Get(char symbol) => Get(symbol.ToString());

        bool IsVowel(char c);

        bool IsConsonant(char c);

        bool IsFrontVowel(char c);

        IReadOnlyCollection<Phoneme> AllPhonemes { get; }
    }
}
