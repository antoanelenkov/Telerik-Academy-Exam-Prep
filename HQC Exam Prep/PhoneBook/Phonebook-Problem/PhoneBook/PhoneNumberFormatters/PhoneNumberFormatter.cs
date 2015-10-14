namespace PhoneBook.PhoneNumberFormatters
{
    using System.Text;

    using Common.Constants;
    using Contracts;

    public class PhoneNumberFormatter:IPhoneNumberFormatter
    {
        public string Format(string phoneNumber)
        {
            StringBuilder formattedPhoneNumber = new StringBuilder();

            foreach (char ch in phoneNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    formattedPhoneNumber.Append(ch);
                }
            }

            if (formattedPhoneNumber.Length >= 2 && formattedPhoneNumber[0] == '0' && formattedPhoneNumber[1] == '0')
            {
                formattedPhoneNumber.Remove(0, 1); formattedPhoneNumber[0] = '+';
            }

            while (formattedPhoneNumber.Length > 0 && formattedPhoneNumber[0] == '0')
            {

                formattedPhoneNumber.Remove(0, 1);
            }

            if (formattedPhoneNumber.Length > 0 && formattedPhoneNumber[0] != '+')
            {
                formattedPhoneNumber.Insert(0, GlobalConstants.CountryCode);
            }

            return formattedPhoneNumber.ToString();
        }
    }
}
