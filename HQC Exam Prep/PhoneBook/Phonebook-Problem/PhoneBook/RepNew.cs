using System;
using System.Collections.Generic;
using System.Linq;
using PhoneBook.Printers;
using PhoneBook.Printers.Contracts;

namespace PhoneBook.Problem_2
{
    internal class RepNew : IPhonebookRepository
    {
        public List<UserEntry> entries = new List<UserEntry>();
        public IPrinter Printer = new ConsolePrinter();

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var old = from e in entries
                where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                select e;

            bool flag;
            if (old.Count() == 0)
            {
                var entry = new UserEntry(name, new SortedSet<string>());

                foreach (var num in nums)
                {
                    entry.Phones.Add(num);
                }

                entries.Add(entry);
                flag = true;
            }
            else if (old.Count() == 1)
            {
                var obj2 = old.First();
                foreach (var num in nums)
                {
                    obj2.Phones.Add(num);
                }
                flag = false;
            }
            else
            {
                Printer.Print("Duplicated name in the phonebook found: " + name);
                return false;
            }

            return flag;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var list = from e in entries where e.Phones.Contains(oldent) select e;

            var nums = 0;
            foreach (var entry in list)
            {
                entry.Phones.Remove(oldent);
                entry.Phones.Add(newent);
                nums++;
            }

            return nums;
        }

        public UserEntry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }
            this.entries.Sort();
            var ent = new UserEntry[num];

            for (var i = start; i <= start + num - 1; i++)
            {
                var entry = entries[i];
                ent[i - start] = entry;
            }

            return ent;
        }
    }
}