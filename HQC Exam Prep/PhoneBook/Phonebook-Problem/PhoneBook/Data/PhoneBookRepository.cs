namespace PhoneBook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class PhoneBookRepository : IPhoneBookRepository
    {
        private IList<IUserEntry> entries = new List<IUserEntry>();

        public void RemovePhone(string phoneNumberToRemove)
        {
            if (phoneNumberToRemove.Substring(0, 1) != "+" || phoneNumberToRemove.Length != 13)
            {
                throw new ArgumentException("Invalid phone number");
            }

            var phoneNumberIsFound = false;
            IUserEntry entryToRemove = null;
            foreach (var entry in this.entries)
            {
                var phoneNumber = entry.Phones.Where(p => p.ToString() == phoneNumberToRemove).FirstOrDefault();

                if (phoneNumber != null)
                {
                    phoneNumberIsFound = true;
                    entry.Phones.Remove(phoneNumber);

                    if (entry.Phones.Count() == 0)
                    {
                        entryToRemove = entry;
                    }
                }
            }

            if (entryToRemove != null)
            {
                this.entries.Remove(entryToRemove);
            }

            if (!phoneNumberIsFound)
            {
                throw new ArgumentException("Phone number could not be found");
            }
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var entryName = this.entries
                .Where(e => e.Name.ToLowerInvariant() == name.ToLowerInvariant()).FirstOrDefault();

            if (entryName == null)
            {
                var entry = new UserEntry(name, new SortedSet<string>());

                foreach (var num in phoneNumbers)
                {
                    entry.Phones.Add(num);
                }

                this.entries.Add(entry);
                return true;
            }
            else
            {
                foreach (var num in phoneNumbers)
                {
                    entryName.Phones.Add(num);
                }

                return false;
            }
        }

        public int ChangePhone(string old, string @new)
        {
            var phones = this.entries.Where(e => e.Phones.Contains(old));

            var changedNumbers = 0;
            foreach (var entry in phones)
            {
                entry.Phones.Remove(old);
                entry.Phones.Add(@new);
                changedNumbers++;
            }

            return changedNumbers;
        }

        public IUserEntry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.OrderBy(x => x.Name);
            IUserEntry[] newEntries = new UserEntry[num];

            for (var i = start; i <= start + num - 1; i++)
            {
                var entry = this.entries[i];
                newEntries[i - start] = entry;
            }

            return newEntries;
        }
    }
}