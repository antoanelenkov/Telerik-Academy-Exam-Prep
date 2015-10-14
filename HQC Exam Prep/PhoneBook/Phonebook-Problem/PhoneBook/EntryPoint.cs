namespace PhoneBook
{
    using System;
    using Common.Enums;
    using PhoneNumberFormatters;
    using PhoneNumberFormatters.Contracts;
    using Printers;
    using Printers.Contracts;
    using Factories.Contracts;
    using Factories;
    using Data.Contracts;
    using OutputMessageFormatters.Contracts;
    using OutputMessageFormatters;
    using Commands.Contracts;
    using Readers.Contracts;
    using Readers;
    using Data;

    internal class EntryPoint
    {
        private static readonly IPhoneBookRepository Data = new PhoneBookRepository(); 
        private static readonly IOutputMessageFormatter Output = new OutputMessageFormatter();
        private static readonly IPrinter Printer = new ConsolePrinter();
        private static readonly IReader Reader = new ConsoleReader();
        private static readonly IPhoneNumberFormatter Formatter = new PhoneNumberFormatter();
        private static readonly ICommandFactory commandFactory = new CommandFactory(Formatter, Data, Output);


        private static void Main()
        {
            while (true)
            {
                var input = Reader.ReadInput();

                if (!IsValidInput(input))
                {
                    break;
                }

                var indexOfLeftBRacket = input.IndexOf('(');
                var typeOfCommand = input.Substring(0, indexOfLeftBRacket);
                var argumentsText = input.Substring(indexOfLeftBRacket + 1, input.Length - indexOfLeftBRacket - 2);
                var arguments = argumentsText.Split(',');

                for (var j = 0; j < arguments.Length; j++)
                {
                    arguments[j] = arguments[j].Trim();
                }

                ICommand command = null;
                if (typeOfCommand.StartsWith("AddPhone") && arguments.Length >= 2)
                {
                    command = commandFactory.CreateCommand(CommandType.AddPhoneNumbers);
                }
                else if ((typeOfCommand == "ChangePhone") && (arguments.Length == 2))
                {
                    command = commandFactory.CreateCommand(CommandType.ChangePhoneNumber);
                }
                else if ((typeOfCommand == "List") && (arguments.Length == 2))
                {
                    command = commandFactory.CreateCommand(CommandType.ListPhoneNumbers);
                }
                else if ((typeOfCommand == "Remove") && (arguments.Length == 1))
                {
                    command = commandFactory.CreateCommand(CommandType.RemovePhoneNumber);
                }
                else
                {
                    Printer.Print("Invalid format of input!");
                    Environment.Exit(0);
                }

                if (command != null)
                {
                    command.Execute(arguments);
                }
            }

            Printer.Print(Output.ToString());
        }

        private static bool IsValidInput(string input)
        {
            if (input == "End" || input == null)
            {
                return false;
            }

            var indexOfLeftBRacket = input.IndexOf('(');

            if (indexOfLeftBRacket == -1)
            {
                Printer.Print("error!");
                return false;
            }

            if (!input.EndsWith(")"))
            {
                return false;
            }

            return true;
        }
    }
}