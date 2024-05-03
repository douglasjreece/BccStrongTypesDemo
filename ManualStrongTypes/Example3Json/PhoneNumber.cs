using System.Text.Json.Serialization;
using System.Text.Json;

namespace ManualStrongTypes.Example3Json
{
    [JsonConverter(typeof(JsonConverter))]
    public class PhoneNumber
    {
        public string Value { get; private init; }

        public PhoneNumber(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is PhoneNumber phoneNumber &&
                   Value == phoneNumber.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
        
        public static bool operator ==(PhoneNumber? left, PhoneNumber? right)
        {
            return EqualityComparer<PhoneNumber>.Default.Equals(left, right);
        }

        public static bool operator !=(PhoneNumber? left, PhoneNumber? right)
        {
            return !(left == right);
        }

        public static implicit operator PhoneNumber?(string? value)
        {
            return value is not null ? new(value) : null;
        }

        public static implicit operator string(PhoneNumber phoneNumber)
        {
            return phoneNumber.Value;
        }

        public class JsonConverter : JsonConverter<PhoneNumber>
        {
            public override PhoneNumber Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return new(reader.GetString()!);
            }

            public override void Write(Utf8JsonWriter writer, PhoneNumber value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value);
            }
        }
    }
}
