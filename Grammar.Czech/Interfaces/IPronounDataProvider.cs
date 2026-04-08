using Grammar.Czech.Models;
using Grammar.Czech.Models.Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to pronoun data.
    /// </summary>
    public interface IPronounDataProvider
    {
        /// <summary>
        /// Gets Pronouns.
        /// </summary>
        /// <returns>The loaded pronoun metadata keyed by lemma.</returns>
        public Dictionary<string, PronounData> GetPronouns();

        /// <summary>
        /// Gets Paradigms.
        /// </summary>
        /// <returns>The loaded pronoun paradigms keyed by paradigm identifier.</returns>
        public Dictionary<string, PronounParadigm> GetParadigms();
    }
}
