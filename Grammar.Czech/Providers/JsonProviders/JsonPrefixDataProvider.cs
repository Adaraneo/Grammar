using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;

namespace Grammar.Czech.Providers.JsonProviders
{
    public class JsonPrefixDataProvider : IPrefixDataProvider
    {
        private readonly string _prefixPath;
        private Dictionary<string, List<string>> _prefixes;

        public JsonPrefixDataProvider(string dataPath)
        {
            this._prefixPath = Path.Combine(dataPath, "prefixes.json");
        }

        public Dictionary<string, List<string>> GetPrefixes()
        {
            if (_prefixes == null)
            {
                _prefixes = JsonLoader.LoadDictionaryFromFile<List<string>>(_prefixPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _prefixes;
        }
    }
}
