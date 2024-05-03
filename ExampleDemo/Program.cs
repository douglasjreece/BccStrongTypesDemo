namespace ExampleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new() { FirstName = "John", LastName = "Doe" };
            var json = person.ToJson();
            Console.WriteLine(json);
        }
    }
}
