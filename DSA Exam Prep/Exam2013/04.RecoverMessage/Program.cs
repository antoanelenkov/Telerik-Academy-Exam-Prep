using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RecoverMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var all = int.Parse(Console.ReadLine());
            var set = new HashSet<char>();

            for (int i = 0; i < all; i++)
            {
                var message = Console.ReadLine();
                foreach (var letter in message)
                {
                    set.Add(letter);
                }
            }
        }
    }
}
