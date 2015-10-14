namespace PhoneBook.Commands
{
    using System;
    using PhoneBook.Commands.Contracts;

    class NullCommand : ICommand
    {
        public void Execute(string[] input)
        {            
        }
    }
}
