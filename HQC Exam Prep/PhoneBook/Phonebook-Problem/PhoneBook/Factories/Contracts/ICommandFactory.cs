namespace PhoneBook.Factories.Contracts
{
    using Commands.Contracts;
    using Common.Enums;

    public interface ICommandFactory
    {
        ICommand CreateCommand(CommandType type);
    }
}
