using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Czech.Models
{
    public sealed record PronounFormOptions(
        bool AfterPreposition = false,
        bool PreferClitic = false,
        bool PreferRare = false
        );
}
