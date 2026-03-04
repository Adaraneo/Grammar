using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Providers.JsonProviders
{
    public class JsonPrepositionsDataProvider : IPrepositionDataProvider
    {
        private readonly string _prepositionsPath;
        private Dictionary<string, PrepositionData> _data;

        public JsonPrepositionsDataProvider(string dataPath)
        {
            this._prepositionsPath = Path.Combine(dataPath, "prepositions.json");
        }

        public Dictionary<string, PrepositionData> GetPrepositions()
        {
            if (_data == null)
            {
                _data = JsonLoader.LoadDictionaryFromFile<PrepositionData>(_prepositionsPath, Helpers.JsonHelpers.SerializerOptions)!;
            }

            return _data;
        }
    }
}
