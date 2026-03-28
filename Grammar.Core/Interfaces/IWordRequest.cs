using Grammar.Core.Enums;
using System.Text.Json.Serialization;

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
        public bool? IsIndeclinable { get; }
        public bool? IsPluralOnly { get; }
    }
}
