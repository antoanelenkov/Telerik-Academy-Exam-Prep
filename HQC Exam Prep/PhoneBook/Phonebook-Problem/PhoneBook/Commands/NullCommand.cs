namespace PhoneBook.Commands
{
    using Contracts;

    internal class NullCommand : ICommand
    {
        public void Execute(string[] input)
        {            
        }
    }
}
