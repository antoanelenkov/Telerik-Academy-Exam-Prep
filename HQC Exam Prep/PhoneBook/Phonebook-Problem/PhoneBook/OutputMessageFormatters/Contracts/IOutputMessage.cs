using System.Text;

namespace PhoneBook.OutputMessageFormatters.Contracts
{
    interface IOutputMessageFormatter
    {
        StringBuilder Output { get; set; }

        void AddToOutputMessage(string text);
    }
}
