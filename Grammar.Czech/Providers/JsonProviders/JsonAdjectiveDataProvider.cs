using Grammar.Core.Helpers;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads adjective data provider from embedded JSON resources.
    /// </summary>
    public class JsonAdjectiveDataProvider : IAdjectiveDataProvider
    {
        private readonly string _patternPath = "Data.Rules.Adjectives.patterns";
        private readonly Lazy<Dictionary<string, AdjectivePattern>> _patterns;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonAdjectiveDataProvider"/> type.
        /// </summary>
        public JsonAdjectiveDataProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _patterns = new Lazy<Dictionary<string, AdjectivePattern>>(() => JsonLoader.LoadDictionaryFromFile<AdjectivePattern>(assembly, _patternPath, JsonHelpers.SerializerOptions)!);
        }

        /// <summary>
        /// Gets regular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded adjective declension patterns keyed by pattern name.</returns>
        public Dictionary<string, AdjectivePattern> GetPatterns() => _patterns.Value;
    }
}
