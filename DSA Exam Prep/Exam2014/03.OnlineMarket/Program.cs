using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OnlineMarket
{
    enum CommandType
    {
        Add,
        FilterByPriceFromMinToMax,
        FilterByPriceFromMin,
        FilterByPriceToMax,
        FilterByType,
        End
    }

  
  
 

    class Program
    {
        static void Main(string[] args)
        {
            Console.SetIn(new StreamReader("input1.txt"));
            var market = new SuperMarket();

            var input = string.Empty;
            var result = new StringBuilder();

            do
            {
                input = Console.ReadLine();
                var words = input.Split(' ');
                var command = ParseCommand(input);

                if (command == CommandType.Add)
                {
                    var respond = market.Add(words[1], double.Parse(words[2]), words[3]);
                    result.AppendLine(respond);
                }
                else if (command == CommandType.FilterByType)
                {
                    var respond = market.FilterByType(words[3]);
                    result.AppendLine(respond);
                }
                else if (command == CommandType.FilterByPriceFromMin)
                {
                    var respond = market.Filter(double.Parse(words[4]));
                    result.AppendLine(respond);
                }
                else if (command == CommandType.FilterByPriceToMax)
                {
                    var respond = market.Filter(0,double.Parse(words[4]));
                    result.AppendLine(respond);
                }
                else if (command == CommandType.FilterByPriceFromMinToMax)
                {
                    var respond = market.Filter(double.Parse(words[4]), double.Parse(words[6]));
                    result.AppendLine(respond);
                }

            }
            while (input != "end");
            
            Console.WriteLine(result.ToString().Trim());
        }

        private static CommandType ParseCommand(string input)
        {
            var words = input.Split(' ');
            var command = words[0];

            if (command == "add")
            {
                return CommandType.Add;
            }
            else if (command == "end")
            {
                return CommandType.End;
            }
            else if (command == "filter")
            {
                var criteria = words[2];
                if (criteria == "type")
                {
                    return CommandType.FilterByType;
                }
                else if (criteria == "price")
                {
                    if (words.Length == 7)
                    {
                        return CommandType.FilterByPriceFromMinToMax;
                    }
                    else if (words[3] == "from")
                    {
                        return CommandType.FilterByPriceFromMin;
                    }
                    else
                    {
                        return CommandType.FilterByPriceToMax;
                    }
                }
            }

            throw new ArgumentException("invalid command");
        }
    }
}
