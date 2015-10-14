using System.Text;

namespace PhoneBook.OutputMessage.Contracts
{
    interface IOutputMessage
    {
        StringBuilder Output { get; set; }

        void AddToOutputMessage(string text);
    }
}
