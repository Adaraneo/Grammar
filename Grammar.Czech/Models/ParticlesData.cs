namespace Grammar.Czech.Models
{
    public sealed record ConditionalParticles
    {
        public IReadOnlyDictionary<string, string> Plural { get; init; }
        public IReadOnlyDictionary<string, string> Singular { get; init; }
    }

    public sealed record ParticlesData
    {
        public ConditionalParticles Conditional { get; init; }
        public ReflexiveParticles Reflexive { get; init; }
    }

    public sealed record ReflexiveParticles
    {
        public string Dative { get; init; }
        public string Standard { get; init; }
    }
}