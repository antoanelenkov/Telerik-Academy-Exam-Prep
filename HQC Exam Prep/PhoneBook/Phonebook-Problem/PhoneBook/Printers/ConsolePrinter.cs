namespace PhoneBook.Printers
{
    using Contracts;
    using System;

    class ConsolePrinter : IPrinter
    {
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
