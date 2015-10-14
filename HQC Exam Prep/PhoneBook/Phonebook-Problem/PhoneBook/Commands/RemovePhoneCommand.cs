namespace PhoneBook.Commands
{
    using Contracts;
    using Data.Contracts;
    using OutputMessageFormatters.Contracts;
    using PhoneNumberFormatters.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class RemovePhoneCommand:ICommand
    {
        private readonly IPhoneBookRepository data;
        private readonly IPhoneNumberFormatter formatter;
        private readonly IOutputMessageFormatter output;

        public RemovePhoneCommand(IPhoneNumberFormatter formatter, IPhoneBookRepository data, IOutputMessageFormatter output)
        {
            this.formatter = formatter;
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] input)
        {
            var phoneNumber = formatter.Format(input[0]);

            try
            {
                this.data.RemovePhone(phoneNumber);
            }
            catch(ArgumentException ex)
            {
                this.output.AddToOutputMessage(ex.Message);
            }
        }
    }
}
