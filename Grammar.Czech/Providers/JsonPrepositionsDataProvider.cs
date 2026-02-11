using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Providers
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
