namespace Grammar.Czech.Interfaces
{
    /// <summary>
    /// Provides access to prefix data.
    /// </summary>
    public interface IPrefixDataProvider
    {
        /// <summary>
        /// Gets the prefix metadata loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded prefix groups keyed by prefix category.</returns>
        public Dictionary<string, List<string>> GetPrefixes();
    }
}
