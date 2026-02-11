namespace Grammar.Czech.Models
{
    public sealed record VerbTenseForms
    {
        public IReadOnlyDictionary<string, string>? Plural { get; init; }

        // Present/Future: number → person
        public IReadOnlyDictionary<string, string>? Singular { get; init; }
    }
}