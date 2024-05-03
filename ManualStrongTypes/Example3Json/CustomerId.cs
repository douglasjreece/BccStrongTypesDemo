using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManualStrongTypes.Example3Json
{
    [JsonConverter(typeof(JsonConverter))]
    public readonly struct CustomerId
    {
        public int Value { get; private init; }

        public CustomerId(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is CustomerId customerId &&
                   Value == customerId.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(CustomerId left, CustomerId right)
        {
            return EqualityComparer<CustomerId>.Default.Equals(left, right);
        }

        public static bool operator !=(CustomerId left, CustomerId right)
        {
            return !(left == right);
        }

        public static implicit operator CustomerId(int value)
        {
            return new(value);
        }

        public static implicit operator int(CustomerId CustomerId)
        {
            return CustomerId.Value;
        }

        public class JsonConverter : JsonConverter<CustomerId>
        {
            public override CustomerId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return new(int.Parse(reader.GetString()!));
            }

            public override void Write(Utf8JsonWriter writer, CustomerId value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Value.ToString());
            }
        }
    }
}
