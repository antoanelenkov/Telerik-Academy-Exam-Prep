using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth2
{

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
        private static int counter = 0;
        private static SortedSet<int> set = new SortedSet<int>();

        static void Main(string[] args)
        {
            //Console.SetIn(new StreamReader("./input2.txt"));
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
            TraverseMatrix(matrix, startCoordinate);
            Console.WriteLine(set.First());
            //PrintMatrix(matrix);
        }

        private static void TraverseMatrix(string[,,] matrix, Coordinates nextCoord)
        {
            if (counter >= set.First())
            {
                return;
            }

            if (nextCoord.R < 0 || nextCoord.C < 0 || nextCoord.C > matrix.GetLength(2)-1 || nextCoord.R > matrix.GetLength(1)-1)
            {
                return;
            }

            if (nextCoord.L < 0 || nextCoord.L > matrix.GetLength(0)-1)
            {
                set.Add(counter);
                return;
            }

            if (matrix[nextCoord.L, nextCoord.R, nextCoord.C] == "#") { return; }

            if (matrix[nextCoord.L, nextCoord.R, nextCoord.C] == "U")
            {
                matrix[nextCoord.L, nextCoord.R, nextCoord.C] = "R";
                counter++;

                var newCoord = new Coordinates(nextCoord.L + 1, nextCoord.R, nextCoord.C);
                TraverseMatrix(matrix, newCoord);

                matrix[nextCoord.L, nextCoord.R, nextCoord.C] = "U";
                counter--;
            }
            else if (matrix[nextCoord.L, nextCoord.R, nextCoord.C] == "D")
            {
                matrix[nextCoord.L, nextCoord.R, nextCoord.C] = "R";
                counter++;

                var newCoord = new Coordinates(nextCoord.L - 1, nextCoord.R, nextCoord.C);
                TraverseMatrix(matrix, newCoord);

                matrix[nextCoord.L, nextCoord.R, nextCoord.C] = "U";
                counter--;
            }
            else if(matrix[nextCoord.L, nextCoord.R, nextCoord.C] == ".")
            {
                matrix[nextCoord.L, nextCoord.R, nextCoord.C] = "R";
                counter++;

                var newCoord = new Coordinates(nextCoord.L, nextCoord.R+1, nextCoord.C);
                TraverseMatrix(matrix, newCoord);

                newCoord = new Coordinates(nextCoord.L, nextCoord.R , nextCoord.C+1);
                TraverseMatrix(matrix, newCoord);

                newCoord = new Coordinates(nextCoord.L, nextCoord.R, nextCoord.C -1);
                TraverseMatrix(matrix, newCoord);

                newCoord = new Coordinates(nextCoord.L, nextCoord.R-1, nextCoord.C);
                TraverseMatrix(matrix, newCoord);

                matrix[nextCoord.L, nextCoord.R, nextCoord.C] = ".";
                counter--;
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
