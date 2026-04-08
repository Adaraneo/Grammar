using Grammar.Core.Helpers;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads prepositions data provider from embedded JSON resources.
    /// </summary>
    public class JsonPrepositionsDataProvider : IPrepositionDataProvider
    {
        private readonly string _prepositionsPath = "Data.Rules.prepositions";
        private readonly Lazy<Dictionary<string, PrepositionData>> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPrepositionsDataProvider"/> type.
        /// </summary>
        public JsonPrepositionsDataProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _data = new Lazy<Dictionary<string, PrepositionData>>(() => JsonLoader.LoadDictionaryFromFile<PrepositionData>(assembly, _prepositionsPath, JsonHelpers.SerializerOptions)!);
        }

        /// <summary>
        /// Gets Czech preposition metadata loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded preposition data keyed by preposition form.</returns>
        public Dictionary<string, PrepositionData> GetPrepositions() => _data.Value;
    }
}
