﻿namespace PhoneBook.Commands
{
    using System.Linq;
    using Contracts;
    using Data.Contracts;
    using PhoneNumberFormatters.Contracts;
    using OutputMessageFormatters.Contracts;

    internal class AddPhoneCommand : ICommand
    {
        private readonly IPhoneBookRepository data;
        private readonly IPhoneNumberFormatter formatter;
        private readonly IOutputMessageFormatter output;

        public AddPhoneCommand(IPhoneNumberFormatter formatter, IPhoneBookRepository data, IOutputMessageFormatter output)
        {
            this.formatter = formatter;
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] input)
        {
            var name = input[0];
            var phoneNumbers = input.Skip(1).ToList();

            for (var i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = formatter.Format(phoneNumbers[i]);
            }

            var isAdded = data.AddPhone(name, phoneNumbers);

            if (isAdded)
            {
                output.AddToOutputMessage("Phone entry created.");
            }
            else
            {
                output.AddToOutputMessage("Phone entry merged");
            }
        }
    }
}