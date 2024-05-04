using GeneratedStrongTypes.Example2Validation;
using System.Text.RegularExpressions;

namespace GeneratedDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PhoneNumber good = "123-456-7890"!;
                Console.WriteLine(good);

                //PhoneNumber bad = "123-456-78900"!;
                //Console.WriteLine(bad);

                // Parameter passing
                //Traditional.WritePhoneNumber("123-456-78900"!);
                //Strong.WritePhoneNumber("123-456-78900"!);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        static class Traditional
        {
            public static void WritePhoneNumber(string phoneNumber)
            {
                if (!Regex.IsMatch(phoneNumber, @"^\d{3}-\d{3}-\d{4}$"))
                {
                    throw new ArgumentException($"Invalid phone number format: {phoneNumber}");
                }
                Console.WriteLine($"Phone number is: {phoneNumber}");
            }
        }

        static class Strong
        {
            public static void WritePhoneNumber(PhoneNumber phoneNumber)
            {
                Console.WriteLine($"Phone number is: {phoneNumber}");
            }
        }
    }
}
