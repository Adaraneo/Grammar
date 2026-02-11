using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Grammar.Core.Helpers
{
    public static class JsonLoader
    {
        public static List<T> LoadListFromFile<T>(string path, JsonSerializerOptions options)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json, options)!;
        }

        public static Dictionary<string, T> LoadDictionaryFromFile<T>(string path, JsonSerializerOptions options)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Dictionary<string, T>>(json, options)!;
        }
    }
}
