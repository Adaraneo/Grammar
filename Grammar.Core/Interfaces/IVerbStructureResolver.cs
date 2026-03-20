using Grammar.Core.Models.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Interfaces
{
    public interface IVerbStructureResolver<TWord> where TWord : IWordRequest
    {
        VerbStructure AnalyzeVerbStructure(TWord wordRequest);
    }
}
