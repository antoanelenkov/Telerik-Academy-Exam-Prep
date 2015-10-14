namespace PhoneBook.Readers
{
    using System;

    using Contracts;

    internal class ConsoleReader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
