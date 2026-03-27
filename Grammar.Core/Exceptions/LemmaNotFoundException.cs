namespace Grammar.Core.Exceptions
{
    /// <summary>
    /// Thrown when a lemma is not found in the lexical dictionary
    /// and no fallback heuristic is available or permitted.
    /// </summary>
    /// <remarks>
    /// This exception signals a data gap, not a code bug.
    /// The correct fix is always to add the missing lemma to <c>lexicon.json</c>,
    /// not to add a code branch.
    /// </remarks>
    public sealed class LemmaNotFoundException : Exception
    {
        /// <summary>Gets the lemma that was not found in the lexicon.</summary>
        public string Lemma { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="LemmaNotFoundException"/>
        /// for the specified lemma.
        /// </summary>
        /// <param name="lemma">The lemma that was not found.</param>
        public LemmaNotFoundException(string lemma)
            : base($"Lemma '{lemma}' was not found in the lexicon. Add it to lexicon.json.")
        {
            Lemma = lemma;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LemmaNotFoundException"/>
        /// with a custom message and the missing lemma.
        /// </summary>
        /// <param name="lemma">The lemma that was not found.</param>
        /// <param name="message">A custom message providing additional context.</param>
        public LemmaNotFoundException(string lemma, string message)
            : base(message)
        {
            Lemma = lemma;
        }
    }
}
