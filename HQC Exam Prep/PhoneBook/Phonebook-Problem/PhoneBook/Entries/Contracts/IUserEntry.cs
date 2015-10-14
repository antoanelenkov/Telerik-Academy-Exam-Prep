using System.Collections.Generic;

namespace PhoneBook.Problem_2
{
    internal interface IUserEntry
    {
        ISet<string> Phones { get; set; }

        string Name { get; set; }

        int CompareTo(UserEntry other);
        string ToString();
    }
}