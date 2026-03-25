using Grammar.Core.Models.Valency;

namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Provides access to the lexical and valency dictionary.
    /// </summary>
    /// <remarks>
    /// The default implementation is <c>JsonValencyProvider</c> backed by embedded JSON.
    /// The architecture allows a future swap to an SQLite or API-backed provider
    /// without changing any call sites — only the DI registration changes.
    /// </remarks>
    public interface IValencyProvider
    {
        /// <summary>
        /// Returns the lexical entry for the given lemma, or <c>null</c> if not registered.
        /// </summary>
        /// <param name="lemma">The dictionary form of the word (case-insensitive).</param>
        LexicalEntry? GetEntry(string lemma);

        /// <summary>
        /// Returns all valency frames registered for the given verb lemma.
        /// Returns an empty sequence when the lemma has no registered frames.
        /// </summary>
        /// <param name="verbLemma">The infinitive form of the verb (case-insensitive).</param>
        IEnumerable<ValencyFrame> GetFrames(string verbLemma);

        /// <summary>
        /// Returns <c>true</c> when a lexical entry exists for the given lemma.
        /// </summary>
        /// <param name="lemma">The dictionary form of the word (case-insensitive).</param>
        bool HasEntry(string lemma);
    }
}
