namespace Grammar.Core.Interfaces
{
    /// <summary>
    /// Defines the contract for Grammar Plugin.
    /// </summary>
    public interface IGrammarPlugin
    {
        /// <summary>
        /// Gets language code.
        /// </summary>
        string LanguageCode { get; }
    }
}
