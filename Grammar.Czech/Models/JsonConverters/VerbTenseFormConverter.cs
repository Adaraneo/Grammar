using System.Text.Json;
using System.Text.Json.Serialization;

namespace Grammar.Czech.Models.JsonConverters
{
    /// <summary>
    /// Converts JSON values for verb Tense Forms.
    /// </summary>
    public class VerbTenseFormsConverter : JsonConverter<VerbTenseForms>
    {
        /// <summary>
        /// Reads verb tense forms from a JSON object containing singular and plural form groups.
        /// </summary>
        /// <param name="reader">The JSON reader positioned at the tense forms object.</param>
        /// <param name="typeToConvert">The target type requested by the serializer.</param>
        /// <param name="options">The JSON serializer options used to deserialize the resource.</param>
        /// <returns>The deserialized verb tense forms.</returns>
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

        /// <summary>
        /// Writes verb tense forms to JSON.
        /// </summary>
        /// <param name="writer">The JSON writer used by the serializer.</param>
        /// <param name="value">The verb tense forms to write.</param>
        /// <param name="options">The JSON serializer options used to serialize the resource.</param>
        public override void Write(Utf8JsonWriter writer, VerbTenseForms value, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Serialization is not supported.");
        }
    }
}
