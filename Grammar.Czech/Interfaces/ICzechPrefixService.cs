using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;

namespace Grammar.Czech.Interfaces
{
    public interface ICzechPrefixService
    {
        string FindPerfectivePrefix(string lemma);
        string GetNegativePrefix();
        bool HasPerfectivePrefix(string lemma);
    }
}
