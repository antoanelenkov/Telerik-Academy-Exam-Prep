namespace PhoneBook.Printers
{
    using System;

    using Contracts;

    internal class ConsolePrinter : IPrinter
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
