using Grammar.Core.Enums;

namespace Grammar.Czech.Interfaces
{
    public interface ICzechParticleService
    {
        string GetConditionalParticle(Number? number, Person? person);

        string GetReflexive(bool isDative = false);
    }
}
