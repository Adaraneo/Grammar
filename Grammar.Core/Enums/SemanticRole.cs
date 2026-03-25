namespace Grammar.Core.Enums
{
    /// <summary>
    /// Identifies the thematic (semantic) role of an argument within a valency frame.
    /// These roles are language-universal and belong to <c>Grammar.Core</c>.
    /// </summary>
    public enum SemanticRole
    {
        /// <summary>The agent or doer of the action (typically Nominative).</summary>
        Actor,

        /// <summary>The entity directly affected by the action (typically Accusative).</summary>
        Patient,

        /// <summary>The recipient or beneficiary of a transfer (typically Dative).</summary>
        Addressee,

        /// <summary>The topic, content, or object of mental states (typically Genitive or Locative).</summary>
        Theme,

        /// <summary>The place where the action occurs (typically Locative with a preposition).</summary>
        Location,

        /// <summary>The destination or goal of movement (typically Accusative with a preposition).</summary>
        Direction,

        /// <summary>The source or starting point (typically Genitive with <c>od</c> or <c>z</c>).</summary>
        Origin,

        /// <summary>The means or tool used to perform the action (typically Instrumental).</summary>
        Instrument,

        /// <summary>The entity for whose benefit the action is performed (typically Accusative with <c>pro</c>).</summary>
        Beneficiary,
    }
}
