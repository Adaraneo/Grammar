using Grammar.Core.Enums;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Defines operations for selecting Czech clitic and reflexive particles.
    /// </summary>
    public interface ICzechParticleService
    {
        /// <summary>
        /// Gets the conditional particle for the requested grammatical number and person.
        /// </summary>
        /// <param name="number">The grammatical number supplied by the test data.</param>
        /// <param name="person">The requested grammatical person.</param>
        /// <returns>The matching conditional particle.</returns>
        string GetConditionalParticle(Number? number, Person? person);

        /// <summary>
        /// Gets the reflexive particle for the supplied grammatical context.
        /// </summary>
        /// <param name="isDative">True when the particle should use its dative form; otherwise, false.</param>
        /// <returns>The reflexive particle for the requested case context.</returns>
        string GetReflexive(bool isDative = false);
    }
}
