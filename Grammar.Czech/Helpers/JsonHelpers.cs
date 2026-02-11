using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Grammar.Czech.Models.JsonConverters;

namespace Grammar.Czech.Helpers
{
    public static class JsonHelpers
    {
        internal static JsonSerializerOptions SerializerOptions
        {
            get
            {
                return new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                        new VerbTenseFormsConverter(),
                    },
                };
            }
        }
    }
}
