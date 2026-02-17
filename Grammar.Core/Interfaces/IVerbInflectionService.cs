using Grammar.Core.Models.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Interfaces
{
    public interface IVerbInflectionService<TWord> where TWord : IWordRequest
    {
        WordForm GetBasicForm(TWord wordRequest);
    }
}
