#nullable disable
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Modrinth.JsonConverters
{
    /// <inheritdoc />
    public class JsonStringEnumConverterEx<TEnum> : JsonConverter where TEnum : struct, Enum
    {
        private readonly Dictionary<TEnum, string> _enumToString = new();
        private readonly Dictionary<string, TEnum> _stringToEnum = new();

        /// <inheritdoc />
        public JsonStringEnumConverterEx()
        {
            var type = typeof(TEnum);
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            foreach (var value in values)
            {
                var enumMember = type.GetMember(value.ToString())[0];
                var attr = enumMember.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .Cast<EnumMemberAttribute>()
                    .FirstOrDefault();

                _stringToEnum.Add(value.ToString(), value);

                if (attr?.Value != null)
                {
                    _enumToString.Add(value, attr.Value);
                    _stringToEnum.Add(attr.Value, value);
                }
                else
                {
                    _enumToString.Add(value, value.ToString());
                }
            }
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumValue = (TEnum)value;
            writer.WriteValue(_enumToString[enumValue]);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return default(TEnum);
            }

            var stringValue = reader.Value.ToString();

            if (_stringToEnum == null)
            {
                throw new InvalidOperationException("_stringToEnum dictionary is not initialized.");
            }

            if (_stringToEnum.TryGetValue(stringValue, out var enumValue))
            {
                return enumValue;
            }

            return default(TEnum);
        }

        /// <inheritdoc/>

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TEnum);
        }
    }
}
