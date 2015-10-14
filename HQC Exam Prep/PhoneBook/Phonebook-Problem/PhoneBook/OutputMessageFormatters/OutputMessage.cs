namespace PhoneBook.OutputMessageFormatters
{
    using System.Text;

    using Contracts;

    internal class OutputMessageFormatter : IOutputMessageFormatter
    { 
        public OutputMessageFormatter()
        {
            this.Output = new StringBuilder();
        }

        public StringBuilder Output { get; set; }

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
