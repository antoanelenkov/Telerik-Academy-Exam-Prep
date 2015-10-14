using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Problem_2
{
    internal class UserEntry : IComparable<UserEntry>
    {
        public ISet<string> Phones;

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

        public string ToString()
        {
            var sb = new StringBuilder();

            sb.Append('[');
            sb.Append(Name);

            var flag = true;
            foreach (var phone in Phones)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
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