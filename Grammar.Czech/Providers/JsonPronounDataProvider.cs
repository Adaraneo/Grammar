using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Grammar.Core.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Providers
{
    public class JsonPronounDataProvider : IPronounDataProvider
    {
        private readonly string _pronounPath;
        private Dictionary<string, PronounData>? _data;

        public JsonPronounDataProvider(string dataPath)
        {
            this._pronounPath = Path.Combine(dataPath, "pronouns.json");
        }

        public Dictionary<string, PronounData> GetPronouns()
        {
            if (_data == null)
            {
                _data = JsonLoader.LoadDictionaryFromFile<PronounData>(_pronounPath, Helpers.JsonHelpers.SerializerOptions)!;
            }

            return _data;
        }
    }
}
