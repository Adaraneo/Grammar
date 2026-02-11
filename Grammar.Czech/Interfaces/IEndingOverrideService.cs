using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Interfaces;

namespace Grammar.Czech.Interfaces
{
    public interface IEndingOverrideService<TWord> where TWord : IWordRequest
    {
        string? GetEndingOverride(TWord wordRequest, string defaultEnding);
    }
}
