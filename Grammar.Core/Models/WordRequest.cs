using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Grammar.Core.Enums;
using Grammar.Core.Interfaces;

namespace Grammar.Core.Models
{
    public struct WordRequest : IWordRequest
    {
        public WordRequest() { }

        [JsonPropertyName("Lemma")]
        public string Lemma { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public Number? Number { get; set; }
        public Case? Case { get; set; }
        public Person? Person { get; set; }
        public Tense? Tense { get; set; }
        public VerbAspect? Aspect { get; set; }
        public Modus? Modus { get; set; }
        public Voice? Voice { get; set; }

        [JsonPropertyName("Category")]
        public WordCategory WordCategory { get; set; }
        public string? Pattern { get; set; }
        public string? AdditionalData { get; set; }

        public bool IsNegative { get; set; } = false;
    }
}
