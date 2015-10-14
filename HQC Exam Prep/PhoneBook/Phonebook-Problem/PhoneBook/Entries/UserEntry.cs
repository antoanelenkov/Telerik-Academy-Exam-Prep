namespace PhoneBook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class UserEntry : IComparable<IUserEntry>, IUserEntry
    {
        public UserEntry(string name, ISet<string> phones)
        {
            this.Name = name;
            this.Phones = phones;
        }

        public ISet<string> Phones { get; set; }

        public string Name { get; set; }

        public int CompareTo(IUserEntry other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append('[');
            sb.Append(this.Name);

            var isFirstNumber = true;
            foreach (var phone in this.Phones)
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