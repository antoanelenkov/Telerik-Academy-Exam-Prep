namespace PhoneBook.Commands
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Data;
    using Data.Contracts;
    using OutputMessageFormatters.Contracts;
    using PhoneNumberFormatters.Contracts;

    internal class ListPhoneNumbersCommand : ICommand
    {
        private readonly IPhoneBookRepository data;
        private readonly IPhoneNumberFormatter formatter;
        private readonly IOutputMessageFormatter output;

        public ListPhoneNumbersCommand(IPhoneNumberFormatter formatter, IPhoneBookRepository data, IOutputMessageFormatter output)
        {
            this.formatter = formatter;
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] input)
        {
            try
            {
                IEnumerable<IUserEntry> entries = this.data.ListEntries(int.Parse(input[0]), int.Parse(input[1]));
                foreach (var entry in entries)
                {
                    this.output.AddToOutputMessage(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.output.AddToOutputMessage("Invalid range");
            }
        }
    }
}
