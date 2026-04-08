namespace Grammar.Core.Models.Valency
{
    /// <summary>
    /// Represents valency frame.
    /// </summary>
    public sealed record ValencyFrame
    {
        /// <summary>
        /// Gets or sets verb Lemma.
        /// </summary>
        public string VerbLemma { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets frame Label.
        /// </summary>
        public string? FrameLabel { get; init; }

        /// <summary>
        /// Gets or sets the valency slots required by the frame.
        /// </summary>
        public IReadOnlyList<ValencySlot> Slots { get; init; } = [];
    }
}
