using System.Text.RegularExpressions;

namespace ManualStrongTypes.Example4Partial
{
    public partial class PhoneNumber
    {
        static Exception? Validate(string value)
        {
            return !Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{4}$")
                ? new InvalidOperationException("Invalid phone number format")
                : null;
        }
    }
}
