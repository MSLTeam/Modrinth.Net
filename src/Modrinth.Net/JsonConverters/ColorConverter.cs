using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Modrinth.JsonConverters
{
    /// <inheritdoc />
    public class ColorConverter : JsonConverter<Color?>
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, Color? value, JsonSerializer serializer)
        {
            if (value.HasValue)
            {
                writer.WriteValue(value.Value.ToArgb());
            }
            else
            {
                writer.WriteNull();
            }
        }

        /// <inheritdoc />
        public override Color? ReadJson(JsonReader reader, Type objectType, Color? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                var intValue = Convert.ToInt32(reader.Value);
                return Color.FromArgb(intValue);
            }
            else if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            else
            {
                throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
            }
        }

    }
}
