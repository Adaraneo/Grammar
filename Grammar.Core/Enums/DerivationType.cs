namespace Grammar.Core.Enums
{
    /// <summary>
    /// Specifies the morphological relationship between a root and its derived lexeme.
    /// </summary>
    public enum DerivationType
    {
        /// <summary>The primary (base) derivate — typically the adjective or the simplest form.</summary>
        Primary,

        /// <summary>Female counterpart of the base form (e.g., učitel → učitelka).</summary>
        Feminative,

        /// <summary>Diminutive form expressing smallness or affection (e.g., hrad → hrádek).</summary>
        Diminutive,

        /// <summary>Augmentative form expressing large size or intensity (e.g., kluk → klukisko).</summary>
        Augmentative,

        /// <summary>Agent noun denoting the doer of an action (e.g., učit → učitel).</summary>
        Agentive,

        /// <summary>Abstract nominalisation (e.g., mladý → mladost, mládí).</summary>
        Nominalisation,

        /// <summary>Possessive adjective derived from a noun (e.g., otec → otcův).</summary>
        Possessive,
    }
}
