using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to particle data.
    /// </summary>
    public interface IParticleDataProvider
    {
        /// <summary>
        /// Gets Czech particle data loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded Czech particle definitions.</returns>
        ParticlesData GetParticles();
    }
}
