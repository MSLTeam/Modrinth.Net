using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Modrinth.JsonConverters
{  /// <inheritdoc />
    public class ColorConverter : JsonConverter
    {/// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color?) || objectType == typeof(Color);
        }
        /// <inheritdoc />
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var intValue = Convert.ToInt32(reader.Value);
                    return Color.FromArgb(intValue);
                case JsonToken.Null:
                    return null;
                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
            }
        }
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var color = (Color)value;
                writer.WriteValue(color.ToArgb());
            }
        }
    } 
}
