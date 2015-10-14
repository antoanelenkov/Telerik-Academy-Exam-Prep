namespace PhoneBook.Commands.Contracts
{
    interface ICommand
    {
        void Execute(string[] input);
    }
}
