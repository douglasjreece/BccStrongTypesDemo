namespace ManualStrongTypes.Example1Simple
{
    public class EmailAddress
    {
        public string Value { get; private init; }

        public EmailAddress(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is EmailAddress emailAddress &&
                   Value == emailAddress.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public static bool operator ==(EmailAddress? left, EmailAddress? right)
        {
            return EqualityComparer<EmailAddress>.Default.Equals(left, right);
        }

        public static bool operator !=(EmailAddress? left, EmailAddress? right)
        {
            return !(left == right);
        }

        public static implicit operator EmailAddress?(string? value)
        {
            return value is not null ? new(value) : null;
        }

        public static implicit operator string(EmailAddress phoneNumber)
        {
            return phoneNumber.Value;
        }
    }
}
