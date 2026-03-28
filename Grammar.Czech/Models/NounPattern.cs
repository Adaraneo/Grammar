namespace Grammar.Czech.Models
{
    public sealed record NounPattern
    {
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Endings { get; init; }
        public string Gender { get; init; }

        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>>? Overrides { get; init; }
        public string? Stem { get; init; }
        public string? InheritsFrom { get; init; }
    }
}
