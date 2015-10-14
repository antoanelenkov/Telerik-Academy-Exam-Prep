namespace PhoneBook.Factories
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Commands.Contracts;
    using Common.Enums;
    using Commands;
    using Data.Contracts;
    using PhoneNumberFormatters.Contracts;
    using OutputMessageFormatters.Contracts;

    class CommandFactory : ICommandFactory
    {
        private readonly IPhoneBookRepository data;
        private readonly IPhoneNumberFormatter formatter;
        private readonly IOutputMessageFormatter output;

        public CommandFactory(IPhoneNumberFormatter formatter, IPhoneBookRepository data, IOutputMessageFormatter output)
        {
            this.formatter = formatter;
            this.data = data;
            this.output = output;
        }

        public ICommand CreateCommand(CommandType type)
        {
            switch (type)
            {
                case CommandType.AddPhoneNumbers: { return new AddPhoneCommand(formatter, data, output); }
                case CommandType.ChangePhoneNumber: { return new ChangePhoneCommand(formatter, data, output); }
                case CommandType.ListPhoneNumbers: { return new ListPhoneNumbersCommand(formatter, data, output); }
                case CommandType.RemovePhoneNumber: { return new RemovePhoneCommand(formatter, data, output); }
                default:return new NullCommand();
            }
        }
    }
}
