using ManualStrongTypes.Example1Simple;

namespace Demo1
{
    namespace Weak
    {
        internal interface ICustomerService
        {
            void SetPrimaryCustomerContactAsPhoneNumber(int id, string phoneNumber);
            void SetPrimaryCustomerContactAsEmailAddress(int id, string emailAddress);

            void SetPrimaryCustomerContact(int id, string? phoneNumber, string? emailAddress);

            //void SetPrimaryCustomerContact(int id, string phoneNumber);
            //void SetPrimaryCustomerContact(int id, string emailAddress);
        }
    }

    namespace Strong
    {
        internal interface ICustomerService
        {
            void SetPrimaryCustomerContact(CustomerId id, PhoneNumber phoneNumber);
            void SetPrimaryCustomerContact(CustomerId id, EmailAddress emailAddress);
        }
    }
}
