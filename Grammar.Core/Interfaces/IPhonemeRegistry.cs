using Grammar.Core.Models.Phonology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Interfaces
{
    public interface IPhonemeRegistry
    {
        Phoneme? Get(string symbol);
        Phoneme? Get(char symbol) => Get(symbol.ToString());

        IReadOnlyCollection<Phoneme> AllPhonemes { get; }
    }
}
