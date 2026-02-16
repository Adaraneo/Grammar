using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Models
{
    public class WordStructure
    {
        public string? Prefix { get; set; }
        public string Root { get; set; } = string.Empty;
        public string? DerivationSuffix { get; set; }

        public override string ToString() => $"{Prefix}{Root}{DerivationSuffix}";
    }
}
