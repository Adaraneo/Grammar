using Grammar.Core.Helpers;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads verb data provider from embedded JSON resources.
    /// </summary>
    public class JsonVerbDataProvider : IVerbDataProvider
    {
        private readonly string _patternPath = "Data.Rules.Verbs.patterns";
        private readonly string _irregularPath = "Data.Rules.Verbs.irregulars";
        private readonly Lazy<Dictionary<string, VerbPattern>> _patterns;
        private readonly Lazy<Dictionary<string, VerbPattern>> _irregulars;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonVerbDataProvider"/> type.
        /// </summary>
        public JsonVerbDataProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _irregulars = new Lazy<Dictionary<string, VerbPattern>>(() => JsonLoader.LoadDictionaryFromFile<VerbPattern>(assembly, _irregularPath, JsonHelpers.SerializerOptions)!);
            _patterns = new Lazy<Dictionary<string, VerbPattern>>(() => JsonLoader.LoadDictionaryFromFile<VerbPattern>(assembly, _patternPath, JsonHelpers.SerializerOptions)!);
        }

        /// <summary>
        /// Gets irregular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded irregular verb patterns keyed by lemma or pattern name.</returns>
        public Dictionary<string, VerbPattern> GetIrregulars() => _irregulars.Value;

        /// <summary>
        /// Gets regular inflection patterns loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded verb conjugation patterns keyed by pattern name.</returns>
        public Dictionary<string, VerbPattern> GetPatterns() => _patterns.Value;
    }
}
