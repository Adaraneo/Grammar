using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Grammar.Core.Enums;

namespace Grammar.Core.Interfaces
{
    public interface IWordRequest
    {
        public string Lemma { get; }
        public Gender? Gender { get; }
        public Number? Number { get; }
        public Case? Case { get; }
        public Person? Person { get; }
        public Tense? Tense { get; }
        public VerbAspect? Aspect { get; }
        public Modus? Modus { get; }
        public Voice? Voice { get; }

        [JsonPropertyName("Category")]
        public WordCategory WordCategory { get; }
        public string? Pattern { get; }
        public string? AdditionalData { get; }
        public bool IsNegative { get; }
    }
}
