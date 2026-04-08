using Grammar.Core.Helpers;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads prefix data provider from embedded JSON resources.
    /// </summary>
    public class JsonPrefixDataProvider : IPrefixDataProvider
    {
        private readonly string _prefixPath = "Data.Rules.prefixes";
        private readonly Lazy<Dictionary<string, List<string>>> _prefixes;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPrefixDataProvider"/> type.
        /// </summary>
        public JsonPrefixDataProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _prefixes = new Lazy<Dictionary<string, List<string>>>(() => JsonLoader.LoadDictionaryFromFile<List<string>>(assembly, _prefixPath, JsonHelpers.SerializerOptions)!);
        }

        /// <summary>
        /// Gets Czech prefix metadata loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded prefix groups keyed by prefix category.</returns>
        public Dictionary<string, List<string>> GetPrefixes() => _prefixes.Value;
    }
}
