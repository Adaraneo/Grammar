using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Czech.Interfaces
{
    public interface IOrtographyService
    {
        public string NormalizeEndingOrthography(string stem, string ending);
    }
}
