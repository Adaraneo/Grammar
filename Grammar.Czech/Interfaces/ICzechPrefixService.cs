namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Defines operations for czech Prefix behavior.
    /// </summary>
    public interface ICzechPrefixService
    {
        /// <summary>
        /// Finds the perfective prefix at the beginning of the supplied lemma.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <returns>The matching perfective prefix, or <see langword="null"/> when none is found.</returns>
        string FindPerfectivePrefix(string lemma);

        /// <summary>
        /// Gets the negative prefix used for Czech negation.
        /// </summary>
        /// <returns>The Czech negative prefix.</returns>
        string GetNegativePrefix();

        /// <summary>
        /// Determines whether the supplied lemma starts with a known perfective prefix.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <returns><see langword="true"/> when the lemma has a perfective prefix; otherwise, <see langword="false"/>.</returns>
        bool HasPerfectivePrefix(string lemma);
    }
}
