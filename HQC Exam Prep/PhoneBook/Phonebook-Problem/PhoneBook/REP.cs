using System.Collections.Generic;
using System.Linq;
using PhoneBook.Printers;
using PhoneBook.Printers.Contracts;
using Wintellect.PowerCollections;

namespace PhoneBook.Problem_2
{
    internal class REP : IPhonebookRepository
    {
        private readonly Dictionary<string, UserEntry> entries = new Dictionary<string, UserEntry>();
        private readonly MultiDictionary<string, UserEntry> multidict = new MultiDictionary<string, UserEntry>(false);
        public IPrinter Printer = new ConsolePrinter();
        private readonly OrderedSet<UserEntry> sorted = new OrderedSet<UserEntry>();

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            var nameToCheck = name.ToLowerInvariant();
            UserEntry entry;
            var isNotPesented = entries.TryGetValue(nameToCheck, out entry);

            if (isNotPesented)
            {
                entry = new UserEntry(name, new SortedSet<string>());

                entries.Add(nameToCheck, entry);

                sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                multidict.Add(num, entry);
            }

            entry.Phones.UnionWith(nums);
            return isNotPesented;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(oldent);
                multidict.Remove(oldent, entry);
                entry.Phones.Add(newent);
                multidict.Add(newent, entry);
            }
            return found.Count;
        }

        public UserEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > entries.Count)
            {
                Printer.Print("Invalid start index or count.");
                return null;
            }

            var list = new UserEntry[num];

            for (var i = first; i <= first + num - 1; i++)
            {
                var entry = sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}