namespace PhoneBook.Data
{
    using System.Collections.Generic;

    public interface IUserEntry
    {
        ISet<string> Phones { get; set; }

        string Name { get; set; }

        int CompareTo(IUserEntry other);

        string ToString();
    }
}