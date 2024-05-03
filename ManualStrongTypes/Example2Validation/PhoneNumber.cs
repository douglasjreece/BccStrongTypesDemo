using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManualStrongTypes.Example2Validation
{
    public class PhoneNumber
    {
        public string Value { get; private init; }

        public PhoneNumber(string value)
        {
            if (!IsValid(value)) throw new ArgumentException($"Invalid phone number format: {value}");
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

        public static bool IsValid(string value)
        {
            return Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{4}$");
        }
    }
}
