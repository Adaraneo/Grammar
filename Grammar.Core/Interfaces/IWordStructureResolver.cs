using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Models.Word;

namespace Grammar.Core.Interfaces
{
    public interface IWordStructureResolver<TWord> where TWord: IWordRequest
    {
        WordStructure AnalyzeStructure(TWord wordRequest);
    }
}
