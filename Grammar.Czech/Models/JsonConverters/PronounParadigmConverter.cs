using Grammar.Core.Enums;
using Grammar.Czech.Models.Grammar.Czech.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Grammar.Czech.Models.JsonConverters
{
    /// <summary>
    /// Converts JSON values for pronoun Paradigm.
    /// </summary>
    public class PronounParadigmConverter : JsonConverter<PronounParadigm>
    {
        /// <summary>
        /// Reads a pronoun paradigm from its nested JSON object representation.
        /// </summary>
        /// <param name="reader">The JSON reader positioned at the paradigm object.</param>
        /// <param name="typeToConvert">The target type requested by the serializer.</param>
        /// <param name="options">The JSON serializer options used to deserialize the resource.</param>
        /// <returns>The deserialized pronoun paradigm.</returns>
        public override PronounParadigm Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            var slots = new Dictionary<Number, Dictionary<GenderSlot, Dictionary<Case, string>>>();

            foreach (var numberProp in root.EnumerateObject())
            {
                var number = Enum.Parse<Number>(numberProp.Name);
                var genderSlots = new Dictionary<GenderSlot, Dictionary<Case, string>>();

                foreach (var genderProp in numberProp.Value.EnumerateObject())
                {
                    var genderSlot = Enum.Parse<GenderSlot>(genderProp.Name);
                    var caseForms = new Dictionary<Case, string>();

                    foreach (var caseProp in genderProp.Value.EnumerateObject())
                    {
                        var grammaticalCase = Enum.Parse<Case>(caseProp.Name);
                        caseForms[grammaticalCase] = caseProp.Value.GetString()!;
                    }

                    genderSlots[genderSlot] = caseForms;
                }

                slots[number] = genderSlots;
            }

            return new PronounParadigm { Slots = slots };
        }

        /// <summary>
        /// Writes a pronoun paradigm to JSON.
        /// </summary>
        /// <param name="writer">The JSON writer used by the serializer.</param>
        /// <param name="value">The pronoun paradigm to write.</param>
        /// <param name="options">The JSON serializer options used to serialize the resource.</param>
        public override void Write(Utf8JsonWriter writer, PronounParadigm value, JsonSerializerOptions options)
            => throw new NotImplementedException();
    }
}
