namespace PhoneBook.Data.Contracts
{
    using System.Collections.Generic;

    using Data;

    /// <summary>
    /// Representing repository for operations with phone numbers
    /// </summary>
    public interface IPhoneBookRepository
    {
        /// <summary>
        /// Add phone numbers for certain person in a phonebook
        /// </summary>
        /// <param name="name">name of the owner of the phonenumber</param>
        /// <param name="phoneNumbers">collection of phonenumbers to add</param>
        /// <returns>Returns true if the phonenumbers have been added, otherwise false</returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Replace certain phonenumber with another one.
        /// </summary>
        /// <param name="oldPhoneNumber">the phonenumber to be replaced</param>
        /// <param name="newPhoneNumber">the phonenumber to add</param>
        /// <returns>returns how many phonenumbers have been changed</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Remove certain number serching for it in all entries of phonenumbers
        /// </summary>
        /// <param name="phoneNumberToRemove">the searched phonenumber</param>
        void RemovePhone(string phoneNumberToRemove);

        /// <summary>
        /// Shows all phonenumbers in certain range
        /// </summary>
        /// <param name="startIndex">the page of phonenumbers</param>
        /// <param name="count">the number of phonenumbers per page</param>
        /// <returns>collection of phonenumbers</returns>
        IUserEntry[] ListEntries(int startIndex, int count);
    }
}
