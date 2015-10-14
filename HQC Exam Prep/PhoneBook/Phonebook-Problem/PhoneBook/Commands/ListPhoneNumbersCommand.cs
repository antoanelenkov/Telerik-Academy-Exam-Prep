using PhoneBook.Commands.Contracts;
using PhoneBook.Data.Contracts;
using PhoneBook.OutputMessageFormatters.Contracts;
using PhoneBook.PhoneNumberFormatters.Contracts;
using PhoneBook.Problem_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Commands
{
    class ListPhoneNumbersCommand : ICommand
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
