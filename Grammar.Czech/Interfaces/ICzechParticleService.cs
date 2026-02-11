using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;

namespace Grammar.Czech.Interfaces
{
    public interface ICzechParticleService
    {
        string GetConditionalParticle(Number? number, Person? person);
        string GetReflexive(bool isDative = false);
    }
}
