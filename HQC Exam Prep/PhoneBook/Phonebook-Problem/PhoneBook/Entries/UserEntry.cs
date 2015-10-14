using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Problem_2
{
    internal class UserEntry : IComparable<UserEntry>, IUserEntry
    {
        public ISet<string> Phones { get; set; }

        public UserEntry(string name, ISet<string> phones)
        {
            Name = name;
            Phones = phones;
        }

        public string Name { get; set; }

        public int CompareTo(UserEntry other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append('[');
            sb.Append(Name);

            var isFirstNumber = true;
            foreach (var phone in Phones)
            {
                if (isFirstNumber)
                {
                    sb.Append(": ");
                    isFirstNumber = false;
                }
                else
                {
                    sb.Append(", ");
                }
                sb.Append(phone);
            }
            sb.Append(']');

            return sb.ToString();
        }
    }
}