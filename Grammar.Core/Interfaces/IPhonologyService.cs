using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Interfaces
{
    public interface IPhonologyService<TWord> where TWord : IWordRequest
    {
        string ApplySoftening(string word);
        string RevertSoftening(string word);

        bool HasMobileVowel(string stem);
        string RemoveMobileVowel(string stem);
        string InsertMobileVowel(string stem, int position);

        bool NeedsEpenthesis(string stem, string suffix, TWord request);
        string ApplyEpenthesis(string stem, string suffix, TWord request);
    }
}
