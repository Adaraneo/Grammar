using System.Text.Json;
using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechParticleService : ICzechParticleService
    {
        private readonly IParticleDataProvider dataProvider;
        public CzechParticleService(IParticleDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

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

        public string GetReflexive(bool isDative = false)
        {
            var reflexive = dataProvider.GetParticles().Reflexive;
            return isDative ? reflexive.Dative : reflexive.Standard;
        }
    }
}
