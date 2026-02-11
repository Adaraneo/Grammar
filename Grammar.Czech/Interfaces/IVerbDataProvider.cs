using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface IVerbDataProvider
    {
        Dictionary<string, VerbPattern> GetPatterns();
        Dictionary<string, VerbPattern> GetIrregulars();
    }
}
