namespace PhoneBook.Commands
{
    using System.Linq;

    using Contracts;
    using Data.Contracts;
    using OutputMessageFormatters.Contracts;
    using PhoneNumberFormatters.Contracts;

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
                phoneNumbers[i] = this.formatter.Format(phoneNumbers[i]);
            }

            var isAdded = this.data.AddPhone(name, phoneNumbers);

            if (isAdded)
            {
                this.output.AddToOutputMessage("Phone entry created.");
            }
            else
            {
                this.output.AddToOutputMessage("Phone entry merged");
            }
        }
    }
}