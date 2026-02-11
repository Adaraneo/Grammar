using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Models;

namespace Grammar.Core.Interfaces
{
    public interface IWordFormComposer<TWord> where TWord : IWordRequest
    {
        WordForm GetFullForm(TWord request);
    }
}
