namespace PhoneBook.Commands.Contracts
{
    public interface ICommand
    {
        void Execute(string[] input);
    }
}
