using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Providers
{
    public class JsonVerbDataProvider : IVerbDataProvider
    {
        private readonly string _patternPath;
        private readonly string _irregularPath;
        private Dictionary<string, VerbPattern> _patterns;
        private Dictionary<string, VerbPattern> _irregulars;

        public JsonVerbDataProvider(string dataPath)
        {
            this._patternPath = Path.Combine(dataPath, "verb_patterns.json");
            this._irregularPath = Path.Combine(dataPath, "verb_irregular.json");
        }

        public Dictionary<string, VerbPattern> GetIrregulars()
        {
            if (_irregulars == null)
            {
                _irregulars = JsonLoader.LoadDictionaryFromFile<VerbPattern>(_irregularPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _irregulars;
        }

        public Dictionary<string, VerbPattern> GetPatterns()
        {
            if (_patterns == null)
            {
                _patterns = JsonLoader.LoadDictionaryFromFile<VerbPattern>(_patternPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _patterns;
        }
    }
}
