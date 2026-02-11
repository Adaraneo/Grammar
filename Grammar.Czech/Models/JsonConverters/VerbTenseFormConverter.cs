using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Grammar.Czech.Models.JsonConverters
{
    public class VerbTenseFormsConverter : JsonConverter<VerbTenseForms>
    {
        public override VerbTenseForms Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            IReadOnlyDictionary<string, string>? singular = null, plural = null;

            // Singular
            if (root.TryGetProperty("singular", out var singularProp))
            {
                singular = JsonSerializer.Deserialize<Dictionary<string, string>>(singularProp.GetRawText(), options);
            }

            // Plural
            if (root.TryGetProperty("plural", out var pluralProp))
            {
                plural = JsonSerializer.Deserialize<Dictionary<string, string>>(pluralProp.GetRawText(), options);
            }

            return new VerbTenseForms
            {
                Singular = singular,
                Plural = plural
            };
        }

        public override void Write(Utf8JsonWriter writer, VerbTenseForms value, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Serialization is not supported.");
        }
    }
}