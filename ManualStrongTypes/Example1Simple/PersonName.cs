namespace ManualStrongTypes.Example1Simple
{
    public class PersonName
    {
        public string Value { get; private init; }

        public PersonName(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is PersonName personName &&
                   Value == personName.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(PersonName? left, PersonName? right)
        {
            return EqualityComparer<PersonName>.Default.Equals(left, right);
        }

        public static bool operator !=(PersonName? left, PersonName? right)
        {
            return !(left == right);
        }

        public static implicit operator PersonName?(string? value)
        {
            return value is not null ? new(value) : null;
        }

        public static implicit operator string(PersonName phoneNumber)
        {
            return phoneNumber.Value;
        }
    }
}
