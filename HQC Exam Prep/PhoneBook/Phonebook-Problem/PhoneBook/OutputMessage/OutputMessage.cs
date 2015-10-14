namespace PhoneBook.OutputMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PhoneBook.OutputMessage.Contracts;


    class OutputMessage :IOutputMessage
    {
        public StringBuilder Output { get; set; }
        public void AddToOutputMessage(string text)
        {
            Output.AppendLine(text);
        }
    }
}
