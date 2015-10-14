namespace PhoneBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.Enums;
    using PhoneNumberFormatters;
    using PhoneNumberFormatters.Contracts;
    using Printers;
    using Printers.Contracts;

    namespace Problem_2
    {
        internal class PhoneBookEngine
        {
            private static readonly IPhonebookRepository Data = new RepNew(); // this works!
            private static readonly StringBuilder Output = new StringBuilder();

            private static readonly IPrinter Printer = new ConsolePrinter();
            private static readonly IPhoneNumberFormatter Formatter = new PhoneNumberFormatter();

            private static void Main()
            {
                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "End" || input == null)
                    {
                        // Error reading from console 
                        break;
                    }

                    var indexOfLeftBRacket = input.IndexOf('(');

                    if (indexOfLeftBRacket == -1)
                    {
                        Printer.Print("error!");
                        Environment.Exit(0);
                    }

                    var typeOfCommand = input.Substring(0, indexOfLeftBRacket);

                    if (!input.EndsWith(")"))
                    {
                        break;
                    }

                    var argumentsText = input.Substring(indexOfLeftBRacket + 1, input.Length - indexOfLeftBRacket - 2);
                    var arguments = argumentsText.Split(',');

                    for (var j = 0; j < arguments.Length; j++)
                    {
                        arguments[j] = arguments[j].Trim();
                    }

                    if (typeOfCommand.StartsWith("AddPhone") && arguments.Length >= 2)
                    {
                        ExecuteCommand(CommandType.AddPhoneNumbers, arguments);
                    }
                    else if ((typeOfCommand == "ChangePhone") && (arguments.Length == 2))
                    {
                        ExecuteCommand(CommandType.ChangePhoneNumber, arguments);
                    }
                    else if ((typeOfCommand == "List") && (arguments.Length == 2))
                    {
                        ExecuteCommand(CommandType.ListPhoneNumbers, arguments);
                    }
                    else
                    {
                        Printer.Print("Invalid format of input!");
                        Environment.Exit(0);
                    }
                }

                Printer.Print(Output.ToString());
            }

            private static void ExecuteCommand(CommandType cmd, string[] strings)
            {
                if (cmd == CommandType.AddPhoneNumbers) // first command
                {
                    var name = strings[0];
                    var phoneNumbers = strings.Skip(1).ToList();

                    for (var i = 0; i < phoneNumbers.Count; i++)
                    {
                        phoneNumbers[i] = Formatter.Format(phoneNumbers[i]);
                    }

                    var isAdded = Data.AddPhone(name, phoneNumbers);

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
                    AddToOutputMessage("" + Data.ChangePhone(Formatter.Format(strings[0]), Formatter.Format(strings[1])) +
                                       " numbers changed");
                }
                else if (cmd == CommandType.ListPhoneNumbers)
                {
                    try
                    {
                        IEnumerable<UserEntry> entries = Data.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
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
                Output.AppendLine(text);
            }
        }
    }
}