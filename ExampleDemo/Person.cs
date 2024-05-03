using ExampleSourceGenerator;

namespace ExampleDemo
{
    [ToJson]
    public partial class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
