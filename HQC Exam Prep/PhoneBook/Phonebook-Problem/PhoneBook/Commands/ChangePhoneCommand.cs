﻿using PhoneBook.Commands.Contracts;

namespace PhoneBook.Commands
{
    using Data.Contracts;
    using OutputMessageFormatters.Contracts;
    using PhoneNumberFormatters.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ChangePhoneCommand : ICommand
    {
        private readonly IPhoneBookRepository data;
        private readonly IPhoneNumberFormatter formatter;
        private readonly IOutputMessageFormatter output;

        public ChangePhoneCommand(IPhoneNumberFormatter formatter, IPhoneBookRepository data, IOutputMessageFormatter output)
        {
            this.formatter = formatter;
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] input)
        {
            var changedPhones = this.data.ChangePhone(this.formatter.Format(input[0]), this.formatter.Format(input[1]));

            this.output.AddToOutputMessage(string.Empty + changedPhones + " numbers changed");
        }
    }
}
