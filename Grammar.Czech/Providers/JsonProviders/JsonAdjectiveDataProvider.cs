using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Providers.JsonProviders
{
    public class JsonAdjectiveDataProvider : IAdjectiveDataProvider
    {
        private readonly string _patternPath;
        private Dictionary<string, AdjectivePattern> _patterns;

        public JsonAdjectiveDataProvider(string dataPath)
        {
            this._patternPath = Path.Combine(dataPath, "adjective_patterns.json");
        }

        public Dictionary<string, AdjectivePattern> GetPatterns()
        {
            if (_patterns == null)
            {
                _patterns = JsonLoader.LoadDictionaryFromFile<AdjectivePattern>(_patternPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _patterns;
        }
    }
}
