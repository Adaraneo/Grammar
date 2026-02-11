using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    /// <summary>
    /// Jedna sada tvarů pro konkrétní pád zájmena.
    /// Umožňuje rozlišit příklonky a tvary po předložce.
    /// </summary>
    public sealed record PronounCaseForms
    {
        /// <summary>
        /// Neutrální / nejběžnější tvar (fallback).
        /// </summary>
        public string? Default { get; init; }

        /// <summary>
        /// Tvar po předložce (mně, tobě, něm, ně, nim...).
        /// </summary>
        public string? AfterPreposition { get; init; }

        /// <summary>
        /// Příklonka (mi, ti, ho, mu, ji, je...).
        /// </summary>
        public string? Clitic { get; init; }

        /// <summary>
        /// Knižní / alternativní tvar (mne, tebe...).
        /// </summary>
        public string? Rare { get; init; }
    }

    public sealed record PronounData
    {
        public PronounType Type { get; init; }
        /// <summary>
        /// Pokud je zájmeno skloňované paradigmatem (můj/ten/tento...), odkaz na vzor.
        /// </summary>
        public string? DeclensionPattern { get; init; }
        public Person? Person { get; init; }
        public Number? Number { get; init; }
        public Gender? Gender { get; init; }

        /// <summary>
        /// Pro nepravidelná zájmena (já, ty, on...) nebo pro explicitní výjimky:
        /// pád -> sada možných tvarů.
        /// </summary>
        public Dictionary<Case, PronounCaseForms>? FixedForms { get; init; }
    }
}
