using System.Text.Json.Serialization;
using System.Text.Json;

namespace ManualStrongTypes.Example3Json
{
    [JsonConverter(typeof(JsonConverter))]
    public readonly struct EmployeeId
    {
        public int Value { get; private init; }

        public EmployeeId(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is EmployeeId employeeId &&
                   Value == employeeId.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(EmployeeId left, EmployeeId right)
        {
            return EqualityComparer<EmployeeId>.Default.Equals(left, right);
        }

        public static bool operator !=(EmployeeId left, EmployeeId right)
        {
            return !(left == right);
        }

        public static implicit operator EmployeeId(int value)
        {
            return new(value);
        }

        public static implicit operator int(EmployeeId employeeId)
        {
            return employeeId.Value;
        }

        public class JsonConverter : JsonConverter<EmployeeId>
        {
            public override EmployeeId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return new(int.Parse(reader.GetString()!));
            }

            public override void Write(Utf8JsonWriter writer, EmployeeId value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Value.ToString());
            }
        }
    }
}
