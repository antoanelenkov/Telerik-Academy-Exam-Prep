using PhoneBook.Problem_2;
using System.Collections.Generic;

namespace PhoneBook.Data.Contracts
{
    interface IPhoneBookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        void RemovePhone(string phoneNumberToRemove);

        IUserEntry[] ListEntries(int startIndex, int count);
    }
}
