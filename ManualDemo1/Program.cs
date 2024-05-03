using ManualStrongTypes.Example1Simple;

namespace Scratch
{
    namespace Weak
    {
        record Employee(int Id, string Name, string Email, string Phone);
    }

    namespace Strong
    {
        record Employee(EmployeeId Id, PersonName Name, EmailAddress Email, PhoneNumber Phone);
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerId customerId = 100;
                EmployeeId employeeId = 1000;
                PersonName personName = "John Doe"!;
                PhoneNumber phoneNumber = "123-456-7890"!;
                EmailAddress emailAddress = "me@gmail.com"!;

                //emailAddress = phoneNumber;

                Strong.Employee employee1 = new(employeeId, personName, emailAddress, phoneNumber);
                //Strong.Employee employee2 = new(customerId, emailAddress, personName, phoneNumber);
                //Weak.Employee employee3 = new(customerId, emailAddress, personName, phoneNumber);

                Console.WriteLine(employee1);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

    }
}
