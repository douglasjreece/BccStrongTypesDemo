using ManualStrongTypes.Example1Simple;
using System.Text.Json;

namespace Demo3
{
    namespace Weak
    {
        record Employee(int Id, string Name, string Email, string Phone);
    }

    namespace Strong
    {
        record Employee(EmployeeId Id, PersonName Name, EmailAddress Email, PhoneNumber Phone);
    }

    namespace JsonStrong
    {
        using ManualStrongTypes.Example3Json;
        record Employee(EmployeeId Id, PersonName Name, EmailAddress Email, PhoneNumber Phone);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SerializeWeakEmployee();
            //SerializeStrongEmployee();
            //SerializeJsonStrongEmployee();
        }

        static void SerializeWeakEmployee()
        {
            Console.WriteLine("SerializeWeakEmployee");
            Weak.Employee employee = new(1000, "John Doe", "me@gmail.com", "123-456-7890");
            var json = JsonSerializer.Serialize(employee);
            Console.WriteLine(json);
            Console.WriteLine();
        }

        static void SerializeStrongEmployee()
        {
            Console.WriteLine("SerializeStrongEmployee");
            Strong.Employee employee = new(1000, "John Doe"!, "me@gmail.com"!, "123-456-7890"!);
            var json = JsonSerializer.Serialize(employee);
            Console.WriteLine(json);
            Console.WriteLine();
        }

        static void SerializeJsonStrongEmployee()
        {
            Console.WriteLine("SerializeJsonStrongEmployee");
            JsonStrong.Employee employee = new(1000, "John Doe"!, "me@gmail.com"!, "123-456-7890"!);
            var json = JsonSerializer.Serialize(employee);
            Console.WriteLine(json);
            Console.WriteLine();
        }
    }
}
