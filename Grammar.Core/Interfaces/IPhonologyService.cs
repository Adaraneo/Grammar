using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Interfaces
{
    public interface IPhonologyService
    {
        string ApplySoftening(string word);
        string RevertSoftening(string word);
    }
}
