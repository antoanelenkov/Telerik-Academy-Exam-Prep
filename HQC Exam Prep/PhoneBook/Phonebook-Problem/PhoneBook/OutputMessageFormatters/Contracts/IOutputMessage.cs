namespace PhoneBook.OutputMessageFormatters.Contracts
{
    using System.Text;

    public interface IOutputMessageFormatter
    {
        StringBuilder Output { get; set; }

        void AddToOutputMessage(string text);
    }
}
