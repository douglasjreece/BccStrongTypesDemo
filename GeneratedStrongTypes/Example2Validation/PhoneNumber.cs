using Diabase.StrongTypes;
using System.Text.RegularExpressions;

namespace GeneratedStrongTypes.Example2Validation
{
    [StrongStringType(Constraints = StringConstraint.Required | StringConstraint.Regex, ValidationRequired = true)]
    public partial class PhoneNumber
    {
        private static readonly Regex ConstraintRegEx = new(@"^\d{3}-\d{3}-\d{4}$");
    }
}
