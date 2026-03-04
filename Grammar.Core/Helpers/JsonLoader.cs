using System.Text.Json;

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
