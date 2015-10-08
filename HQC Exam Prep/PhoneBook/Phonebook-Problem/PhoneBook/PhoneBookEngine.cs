using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using PhoneBook.Common.Constants;
using PhoneBook.PhoneNumberFormatters;
using PhoneBook.PhoneNumberFormatters.Contracts;
using PhoneBook.Printers.Contracts;
using PhoneBook.Printers;
using PhoneBook.Common.Enums;

namespace PhoneBook
{
    namespace Problem_2
    {
        class PhoneBookEngine
        {
            private static IPhonebookRepository data = new REPNew(); // this works!
            private static StringBuilder output = new StringBuilder();

            private static IPrinter Printer = new ConsolePrinter();
            private static IPhoneNumberFormatter Formatter = new PhoneNumberFormatter();

            static void Main()
            {
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "End" || input == null)
                    {
                        // Error reading from console 
                        break;
                    }

                    int indexOfLeftBRacket = input.IndexOf('(');

                    if (indexOfLeftBRacket == -1)
                    {
                        Printer.Print("error!"); Environment.Exit(0);
                    }

                    string typeOfCommand = input.Substring(0, indexOfLeftBRacket);

                    if (!input.EndsWith(")"))
                    {
                        break;
                    }

                    string argumentsText = input.Substring(indexOfLeftBRacket + 1, input.Length - indexOfLeftBRacket - 2);
                    string[] arguments = argumentsText.Split(',');

                    for (int j = 0; j < arguments.Length; j++)
                    {
                        arguments[j] = arguments[j].Trim();
                    }

                    if (typeOfCommand.StartsWith("AddPhone") && arguments.Length >= 2)
                    {
                        ExecuteCommand(CommandType.AddPhoneNumbers, arguments);
                    }
                    else if ((typeOfCommand == "ChangeРhone") && (arguments.Length == 2))
                    {
                        ExecuteCommand(CommandType.ChangePhoneNumber, arguments);
                    }
                    else if ((typeOfCommand == "List") && (arguments.Length == 2))
                    {
                        ExecuteCommand(CommandType.ChangePhoneNumber, arguments);
                    }
                    else
                    {
                        Printer.Print("Invalid format of input!");
                        Environment.Exit(0);
                    }
                }

                Printer.Print(output.ToString());
            }

            private static void ExecuteCommand(CommandType cmd, string[] strings)
            {
                if (cmd == CommandType.AddPhoneNumbers) // first command
                {
                    string name = strings[0];
                    var phoneNumbers = strings.Skip(1).ToList();

                    for (int i = 0; i < phoneNumbers.Count; i++)
                    {
                        phoneNumbers[i] = Formatter.Format(phoneNumbers[i]);
                    }

                    bool isAdded = data.AddPhone(name, phoneNumbers);

                    if (isAdded)
                    {
                        AddToOutputMessage("Phone entry created.");
                    }
                    else
                    {
                        AddToOutputMessage("Phone entry merged");
                    }
                }
                else if (cmd == CommandType.ChangePhoneNumber) // second command
                {
                    AddToOutputMessage("" + data.ChangePhone(Formatter.Format(strings[0]), Formatter.Format(strings[1])) + " numbers changed");
                }
                else if (cmd == CommandType.ListPhoneNumbers)
                {
                    try
                    {
                        IEnumerable<UserEntry> entries = data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                        foreach (var entry in entries)
                        {
                            AddToOutputMessage(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        AddToOutputMessage("Invalid range");
                    }
                }
            }

            private static void AddToOutputMessage(string text)
            {
                output.AppendLine(text);
            }
        }

        class UserEntry //: IComparable<UserEntry>
        {
            public UserEntry(string name, ISet<string> phones)
            {
                this.Name = name;
                this.Phones = phones;
            }
            public string Name { get; set; }

            public ISet<string> Phones;

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                sb.Append('[');
                sb.Append(this.Name);

                bool flag = true;
                foreach (var phone in this.Phones)
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

            //public int CompareTo(UserEntry other)
            //{
            //    return this.name2.CompareTo(other.name2);
            //}
        }

        class REPNew : IPhonebookRepository
        {
            public List<UserEntry> entries = new List<UserEntry>();
            public IPrinter Printer = new ConsolePrinter();

            public bool AddPhone(string name, IEnumerable<string> nums)
            {
                var old = from e in this.entries
                          where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                          select e;

                bool flag;
                if (old.Count() == 0)
                {
                    UserEntry entry = new UserEntry(name, new SortedSet<string>());

                    foreach (var num in nums)
                    {
                        entry.Phones.Add(num);
                    }

                    this.entries.Add(entry);
                    flag = true;
                }
                else if (old.Count() == 1)
                {
                    UserEntry obj2 = old.First();
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
                var list = from e in this.entries where e.Phones.Contains(oldent) select e;

                int nums = 0;
                foreach (var entry in list)
                {
                    entry.Phones.Remove(oldent); entry.Phones.Add(newent);
                    nums++;
                }

                return nums;
            }

            public UserEntry[] ListEntries(int start, int num)
            {
                if (start < 0 || start + num > this.entries.Count)
                {
                    throw new ArgumentOutOfRangeException("Invalid start index or count.");
                }
                this.entries.Sort();
                UserEntry[] ent = new UserEntry[num];

                for (int i = start; i <= start + num - 1; i++)
                {
                    UserEntry entry = this.entries[i];
                    ent[i - start] = entry;
                }

                return ent;
            }
        }

        class REP : IPhonebookRepository
        {
            private OrderedSet<UserEntry> sorted = new OrderedSet<UserEntry>();
            private Dictionary<string, UserEntry> entries = new Dictionary<string, UserEntry>();
            private MultiDictionary<string, UserEntry> multidict = new MultiDictionary<string, UserEntry>(false);
            public IPrinter Printer = new ConsolePrinter();

            public bool AddPhone(string name, IEnumerable<string> nums)
            {
                string nameToCheck = name.ToLowerInvariant();
                UserEntry entry;
                bool isNotPesented = this.entries.TryGetValue(nameToCheck, out entry);

                if (isNotPesented)
                {
                    entry = new UserEntry(name, new SortedSet<string>());

                    this.entries.Add(nameToCheck, entry);

                    this.sorted.Add(entry);
                }

                foreach (var num in nums)
                {
                    this.multidict.Add(num, entry);
                }

                entry.Phones.UnionWith(nums);
                return isNotPesented;
            }

            public int ChangePhone(string oldent, string newent)
            {
                var found = this.multidict[oldent].ToList(); foreach (var entry in found)
                {
                    entry.Phones.Remove(oldent);
                    this.multidict.Remove(oldent, entry);
                    entry.Phones.Add(newent); this.multidict.Add(newent, entry);
                }
                return found.Count;
            }

            public UserEntry[] ListEntries(int first, int num)
            {
                if (first < 0 || first + num > this.entries.Count)
                {
                    Printer.Print("Invalid start index or count.");
                    return null;
                }

                UserEntry[] list = new UserEntry[num];

                for (int i = first; i <= first + num - 1; i++)
                {
                    UserEntry entry = this.sorted[i];
                    list[i - first] = entry;
                }

                return list;
            }
        }

        interface IPhonebookRepository
        {
            bool AddPhone(string name, IEnumerable<string> phoneNumbers);

            int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

            UserEntry[] ListEntries(int startIndex, int count);
        }
    }
}
