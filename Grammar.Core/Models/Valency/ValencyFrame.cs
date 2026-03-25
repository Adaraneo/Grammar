namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Represents one syntactic argument frame for a verb lemma.
    /// </summary>
    /// <remarks>
    /// A single verb may have multiple frames, each modelling a different
    /// semantic reading or argument structure.
    /// For example, <c>jít</c> has a motion frame (Actor + Direction)
    /// and a process frame (Actor only: "věci jdou dobře").
    /// </remarks>
    public sealed record ValencyFrame
    {
        /// <summary>Gets the verb lemma this frame belongs to (e.g., "dát").</summary>
        public string VerbLemma { get; init; } = string.Empty;

        /// <summary>
        /// Gets an optional human-readable label identifying this reading
        /// (e.g., "transfer", "motion", "cognition").
        /// </summary>
        public string? FrameLabel { get; init; }

        /// <summary>Gets the ordered list of argument slots in this frame.</summary>
        public IReadOnlyList<ValencySlot> Slots { get; init; } = [];
    }
}
