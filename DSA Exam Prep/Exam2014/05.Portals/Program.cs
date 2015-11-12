namespace _05.Portals
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetIn(new StreamReader("input.txt"));
            var startPosition = Console.ReadLine().Split(' ');
            var size = Console.ReadLine().Split(' ');

            var matrix = new string[int.Parse(size[0]), int.Parse(size[1])];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var buffer = Console.ReadLine().Split(' ');
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = buffer[j];
                }
            }

            FindAllPaths(matrix, int.Parse(startPosition[0]), int.Parse(startPosition[1]), 0);
            Console.WriteLine(bestSum);
        }

        private static long bestSum = 0;
        private static long sum = 0;

        private static void FindAllPaths(string[,] arr, int row, int col, int last)
        {
            if (row < 0 || col < 0 || row >= arr.GetLength(0) || col >= arr.GetLength(1) || arr[row, col] == "v" || arr[row, col] == "#")
            {
                return;
            }

            var power = int.Parse(arr[row, col]);

            var causeException = CauseException(arr, row + power, col) || CauseException(arr, row - power, col) || CauseException(arr, row, col - power) || CauseException(arr, row, col + power);
            if (causeException)
            {
                sum += power;
            }

            if (sum > bestSum)
            {
                bestSum = sum;
            }

            arr[row, col] = "v";
            FindAllPaths(arr, row + power, col, power);
            FindAllPaths(arr, row, col + power, power);
            FindAllPaths(arr, row, col - power, power);
            FindAllPaths(arr, row - power, col, power);
            arr[row, col] = power.ToString();

            if (causeException)
            {
                sum -= power;
            }
        }

        private static bool CauseException(string[,] arr, int row, int col)
        {
            if (row < 0 || col < 0 || row >= arr.GetLength(0) || col >= arr.GetLength(1) || arr[row, col] == "#")
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix<T>(T[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}