
namespace PhoneBook.Readers
{
    using PhoneBook.Readers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ConsoleReader : IReader
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
