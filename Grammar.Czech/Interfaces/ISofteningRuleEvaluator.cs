using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Interfaces;

namespace Grammar.Czech.Interfaces
{
    public interface ISofteningRuleEvaluator<TWord> where TWord : IWordRequest
    {
        bool ShouldApplySoftening(TWord wordRequest);
    }
}
