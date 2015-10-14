using System.Collections.Generic;

namespace PhoneBook.Problem_2
{
    internal interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        UserEntry[] ListEntries(int startIndex, int count);
    }
}