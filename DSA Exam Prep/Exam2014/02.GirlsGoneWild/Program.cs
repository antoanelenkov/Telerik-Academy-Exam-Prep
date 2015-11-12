namespace _02.GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        private static ISet<string> allLetters = new SortedSet<string>();
        private static ISet<string> allNumbers = new SortedSet<string>();
        private static ISet<string> result = new SortedSet<string>();


        private static void VariationsWithoutRepetitions<T>(T[] arr, T[] resultArr, bool[] used, int index, int k, int n)
        {
            if (index >= k)
            {
                //PrintArray(resultArr);
                var output = new StringBuilder();
                foreach (var element in resultArr)
                {
                    output.Append(element);
                }
                allLetters.Add(output.ToString());

                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    resultArr[index] = arr[i];
                    VariationsWithoutRepetitions(arr, resultArr, used, index + 1, k, n);
                    used[i] = false;
                }
            }
        }

        static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            var letters = Console.ReadLine();
            var girls = int.Parse(Console.ReadLine());

            var currentNumbers = new int[girls];
            var currentLetters = new char[girls];

            var variationsOfNumbers = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                variationsOfNumbers[i] = i;
            }
            var variationsOfLetters = letters.ToCharArray();
            var letterUsed = new bool[variationsOfLetters.Length];

            VariationsWithoutRepetitions(variationsOfLetters, currentLetters, letterUsed, 0, girls, variationsOfLetters.Length);
            CombinationsWithoutRepetitions(variationsOfNumbers, currentNumbers, 0, 0, variationsOfNumbers.Length, girls);

            var resultLetters = allLetters.ToList();
            var resultNumbers = allNumbers.ToList();
            var counter = 0;
            for (int i = 0; i < resultNumbers.Count; i++)
            {
                for (int j = 0; j < resultLetters.Count; j++)
                {
                    var sb = new StringBuilder();
                    for (int k = 0; k < girls; k++)
                    {
                        sb.Append(resultNumbers[i][k]);
                        sb.Append(resultLetters[j][k]);
                        if (k == girls - 1)
                        {
                            continue;
                        }
                        sb.Append("-");
                    }
                    counter++;
                    result.Add(sb.ToString());
                }
            }

            Console.WriteLine(counter);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void CombinationsWithoutRepetitions<T>(T[] arr, T[] resultArr, int index, int start, int n, int k)
        {
            if (index >= k)
            {
                //PrintArray(resultArr);
                var output = new StringBuilder();
                foreach (var element in resultArr)
                {
                    output.Append(element);
                }
                allNumbers.Add(output.ToString());
                return;
            }

            for (int i = start; i < n; i++)
            {
                resultArr[index] = arr[i];
                CombinationsWithoutRepetitions(arr, resultArr, index + 1, i + 1, n, k);
            }
        }

        private static void VariationsWithRepetitions<T>(T[] arr,T[] bufferArr, int index,int n,int k)
        {
            if (index >= k)
            {
                PrintArray(bufferArr);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                bufferArr[index] = arr[i];
                VariationsWithRepetitions(arr,bufferArr, index + 1,n,k);
            }
        }


        private static void PrintArray<T>(T[] arr)
        {
            Console.WriteLine(String.Join(", ", arr));
        }
    }
}
