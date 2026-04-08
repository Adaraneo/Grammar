using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;

namespace Grammar.Czech.Services
{
    /// <summary>
    /// Provides Czech clitic and reflexive particle lookup operations.
    /// </summary>
    public class CzechParticleService : ICzechParticleService
    {
        private readonly IParticleDataProvider dataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CzechParticleService"/> type.
        /// </summary>
        public CzechParticleService(IParticleDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// Gets the conditional particle for the requested grammatical number and person.
        /// </summary>
        /// <param name="number">The grammatical number supplied by the test data.</param>
        /// <param name="person">The requested grammatical person.</param>
        /// <returns>The matching conditional particle.</returns>
        public string GetConditionalParticle(Number? number, Person? person)
        {
            if (number == null || person == null)
            {
                throw new ArgumentNullException();
            }

            var conditional = dataProvider.GetParticles().Conditional;
            var section = number == Number.Singular ? conditional.Singular : conditional.Plural;
            return section[((int)person).ToString()];
        }

        /// <summary>
        /// Gets the reflexive particle for the supplied grammatical context.
        /// </summary>
        /// <param name="isDative">True when the particle should use its dative form; otherwise, false.</param>
        /// <returns>The reflexive particle for the requested case context.</returns>
        public string GetReflexive(bool isDative = false)
        {
            var reflexive = dataProvider.GetParticles().Reflexive;
            return isDative ? reflexive.Dative : reflexive.Standard;
        }
    }
}
