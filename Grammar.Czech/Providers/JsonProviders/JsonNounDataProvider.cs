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
    public class JsonNounDataProvider : INounDataProvider
    {
        private readonly string _patternPath;
        private readonly string _irregularPath;
        private readonly string _properNamesPath;
        private Dictionary<string, NounPattern> _patterns;
        private Dictionary<string, NounPattern> _irregulars;
        private Dictionary<string, NounPattern> _properNames;

        public JsonNounDataProvider(string dataPath)
        {
            this._patternPath = Path.Combine(dataPath, "substantive_patterns.json");
            this._irregularPath = Path.Combine(dataPath, "substantive_irregular.json");
            this._properNamesPath = Path.Combine(dataPath, "substantive_proper.json");
        }

        public Dictionary<string, NounPattern> GetPatterns()
        {
            if (_patterns == null)
            {
                _patterns = JsonLoader.LoadDictionaryFromFile<NounPattern>(_patternPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _patterns;
        }

        public Dictionary<string, NounPattern> GetIrregulars()
        {
            if (_irregulars == null)
            {
                _irregulars = JsonLoader.LoadDictionaryFromFile<NounPattern>(_irregularPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _irregulars;
        }

        public Dictionary<string, NounPattern> GetPropers()
        {
            if (_properNames == null)
            {
                _properNames = JsonLoader.LoadDictionaryFromFile<NounPattern>(_properNamesPath, Helpers.JsonHelpers.SerializerOptions);
            }

            return _properNames;
        }
    }

}
