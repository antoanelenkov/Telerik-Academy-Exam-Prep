namespace PhoneBook.OutputMessageFormatters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PhoneBook.OutputMessageFormatters.Contracts;


    class OutputMessageFormatter :IOutputMessageFormatter
    {
        public StringBuilder Output { get; set; }

        public OutputMessageFormatter()
        {
            this.Output = new StringBuilder();
        }

        public void AddToOutputMessage(string text)
        {
            this.Output.AppendLine(text);
        }

        public override string ToString()
        {
            return this.Output.ToString();
        }
    }
}
