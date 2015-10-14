using PhoneBook.Commands.Contracts;
using PhoneBook.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Factories.Contracts
{
    interface ICommandFactory
    {
        ICommand CreateCommand(CommandType type);
    }
}
