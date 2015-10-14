namespace PhoneBook.Data.Contracts
{
    using System.Collections.Generic;

    using Data;

    public interface IPhoneBookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        void RemovePhone(string phoneNumberToRemove);

        IUserEntry[] ListEntries(int startIndex, int count);
    }
}
