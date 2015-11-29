namespace _02.Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Coordinates
    {
        public int L { get; set; }
        public int R { get; set; }
        public int C { get; set; }

        public Coordinates()
        {
        }

        public Coordinates(int l, int r, int c)
        {
            this.L = l;
            this.R = r;
            this.C = c;
        }
    }

    class Program
    {
        private static SortedSet<int> set = new SortedSet<int>();

        static void Main()
        {
            Console.SetIn(new StreamReader("./input.txt"));
            var startingPoints = Console.ReadLine().Split(' ');
            var startCoordinate = new Coordinates(int.Parse(startingPoints[0]), int.Parse(startingPoints[1]), int.Parse(startingPoints[2]));
            var matrixSize = Console.ReadLine().Split(' ');
            var levels = int.Parse(matrixSize[0]);
            var rows = int.Parse(matrixSize[1]);
            var cols = int.Parse(matrixSize[2]);
            string[,,] matrix = new string[levels, rows, cols];

            for (int i = 0; i < levels * rows; i++)
            {
                var row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i / rows, i % rows, j] = row[j].ToString();
                }
            }

            set.Add(int.MaxValue);

            TraverseMatrixRecursion(matrix, startCoordinate,0);
            Console.WriteLine(set.First());
        }
       

        private static void TraverseMatrixRecursion(string[,,] matrix, Coordinates current, int stepsCounter)
        {
            if (stepsCounter > set.First())
            {
                return;
            }

            if (current.C < 0 || current.R < 0 || current.C > matrix.GetLength(2)-1 || current.R > matrix.GetLength(1)-1)
            {
                return;
            }

            if (current.L < 0 || current.L > matrix.GetLength(0)-1)
            {
                set.Add(stepsCounter);
                return;
            }
            else if (matrix[current.L, current.R, current.C] == "U")
            {
                stepsCounter++;
                matrix[current.L, current.R, current.C] = "X";

                var nextCoord = new Coordinates(current.L + 1, current.R, current.C);
                TraverseMatrixRecursion(matrix, nextCoord, stepsCounter);

                matrix[current.L, current.R, current.C] = "U";
                stepsCounter--;

                return;
            }
            else if (matrix[current.L, current.R, current.C] == "D")
            {
                stepsCounter++;
                matrix[current.L, current.R, current.C] = "X";

                var nextCoord = new Coordinates(current.L - 1, current.R, current.C);
                TraverseMatrixRecursion(matrix, nextCoord, stepsCounter);

                matrix[current.L, current.R, current.C] = "D";
                stepsCounter--;

                return;
            }
            else if (matrix[current.L, current.R, current.C] == "#")
            {
                return;
            }
            else if (matrix[current.L, current.R, current.C] == ".")
            {
                stepsCounter++;
                matrix[current.L, current.R, current.C] = "X";

                var nextCoord = new Coordinates(current.L, current.R + 1, current.C);
                TraverseMatrixRecursion(matrix, nextCoord, stepsCounter);

                nextCoord = new Coordinates(current.L, current.R - 1, current.C);
                TraverseMatrixRecursion(matrix, nextCoord, stepsCounter);

                nextCoord = new Coordinates(current.L, current.R, current.C + 1);
                TraverseMatrixRecursion(matrix, nextCoord, stepsCounter);

                nextCoord = new Coordinates(current.L, current.R, current.C - 1);
                TraverseMatrixRecursion(matrix, nextCoord, stepsCounter);

                matrix[current.L, current.R, current.C] = ".";
                stepsCounter--;
            }
        }

        private static void PrintMatrix(string[,,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(2); k++)
                    {
                        Console.Write(matrix[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
