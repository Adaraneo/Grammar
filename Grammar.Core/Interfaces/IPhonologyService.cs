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

        string RemoveMobileVowel(string stem, bool hasMobileVowel);
        string InsertMobileVowel(string stem, int position);

        string ApplyEpenthesis(bool needsEpenthesis, string stem, string suffix);

        string ShortenVowel(string stem);
        string LengthenVowel(string stem);
    }
}
