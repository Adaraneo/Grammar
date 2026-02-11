using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    public sealed record PrepositionData
    {
        public string Preposition { get; init; } = "";
        public PrepositionOriginType OriginType { get; init; }
        public List<PrepositionVariant> Variants { get; init; } = new();
    }

    public sealed record PrepositionVariant
    {
        public Case Case { get; init; }
        public PrepositionSemanticGroup SemanticGroup { get; init; }
    }
}
