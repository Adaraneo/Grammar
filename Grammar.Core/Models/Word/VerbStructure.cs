using Grammar.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Core.Models.Word
{
    /// <summary>
    /// Výsledek morfologické analýzy slovesa — obsahuje VŠECHNY kmeny
    /// nezávisle na čase. Konjugační služba si pak vybere ten správný.
    /// </summary>
    public sealed class VerbStructure
    {
        public string? Prefix { get; set; }

        /// <summary>Kmen přítomného času: pros, děl, kupu, tisk</summary>
        public string PresentStem { get; set; } = string.Empty;

        /// <summary>Kmen minulého času: prosi, děla, kupova, tisk</summary>
        public string PastStem { get; set; } = string.Empty;

        /// <summary>Kmen pasivního participia — pokud null, použije PastStem</summary>
        public string? PassiveStem { get; set; }

        /// <summary>Imperativní kmen — jen pro nepravidelná slovesa (buď, měj...)</summary>
        public string? ImperativeStem { get; set; }

        public VerbAspect Aspect { get; set; }
    }
}
