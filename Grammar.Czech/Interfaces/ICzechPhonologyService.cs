using Grammar.Core.Interfaces;
using Grammar.Czech.Enums.Phonology;
using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Defines Czech-specific phonology operations.
    /// </summary>
    public interface ICzechPhonologyService : IPhonologyService<CzechWordRequest>
    {
        /// <summary>
        /// Applies Czech consonant softening for the supplied palatalization context.
        /// </summary>
        /// <param name="stem">The stem to transform.</param>
        /// <param name="context">The palatalization context used to choose the softening target.</param>
        /// <returns>The stem after context-sensitive consonant softening has been applied.</returns>
        string ApplySoftening(string stem, PalatalizationContext context);
    }
}
