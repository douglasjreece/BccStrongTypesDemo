namespace ManualStrongTypes.Example1Simple
{
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
    }
}
