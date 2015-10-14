namespace PhoneBook.Factories
{
    using Commands;
    using Commands.Contracts;
    using Common.Enums;
    using Contracts;
    using Data.Contracts;
    using OutputMessageFormatters.Contracts;
    using PhoneNumberFormatters.Contracts;

    internal class CommandFactory : ICommandFactory
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
                case CommandType.AddPhoneNumbers:
                    return new AddPhoneCommand(this.formatter, this.data, this.output);
                case CommandType.ChangePhoneNumber:
                        return new ChangePhoneCommand(this.formatter, this.data, this.output);
                case CommandType.ListPhoneNumbers:
                        return new ListPhoneNumbersCommand(this.formatter, this.data, this.output);
                case CommandType.RemovePhoneNumber:
                        return new RemovePhoneCommand(this.formatter, this.data, this.output);
                default: return new NullCommand();
            }
        }
    }
}
