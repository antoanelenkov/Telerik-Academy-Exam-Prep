using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShortestPath
{
    class Program
    {
        private static string input;
        private static int counter = 0;
        private static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            input = Console.ReadLine();
            var possiblePaths = new char[] { 'L', 'R', 'S'};
            var stars = 0;

            foreach (var item in input)
            {
                if (item == '*')
                {
                    stars++;
                }
            }

            var bufferArr = new char[stars];

            VariationsWithRepetitions(possiblePaths, bufferArr, 0, possiblePaths.Length, stars);

            Console.WriteLine(counter);
            var toPrint= result.ToString().Substring(0,result.Length-2);
            Console.WriteLine(toPrint);
        }

        private static void VariationsWithRepetitions(char[] arr, char[] bufferArr, int index, int n, int k)
        {
            if (index >= k)
            {
                PrintArray(bufferArr);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                bufferArr[index] = arr[i];
                VariationsWithRepetitions(arr, bufferArr, index + 1, n, k);
            }
        }

        private static void PrintArray(char[] arr)
        {
            var count = 0;
            var sb = new StringBuilder();
            foreach (var item in input)
            {
                if (item == '*')
                {
                    sb.Append(arr[count++]);
                }
                else
                {
                    sb.Append(item);
                }
            }
            counter++;
            result.AppendLine(sb.ToString());
        }
    }
}
