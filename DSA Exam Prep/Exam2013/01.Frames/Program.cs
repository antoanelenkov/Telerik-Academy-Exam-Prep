namespace _01.Frames
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Frame:IComparable
    {
        public Frame(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Index { get; set; }

        public override int GetHashCode()
        {
            return (this.X^12 * this.Y^12)*37;
        }

        public int CompareTo(object obj)
        {
            var frame = obj as Frame;

            if (this.X > frame.X)
            {
                return 1;
            }
            else if(this.X < frame.X)
            {
                return -1;
            }
            else if (this.Y > frame.Y)
            {
                return 1;
            }
            else if(this.Y < frame.Y)
            {
                return -1;
            }

            return 0;
        }
    }

    class Program
    {
        private static List<Frame> frames = new List<Frame>();
        private static int permutations = 0;
        private static StringBuilder result = new StringBuilder();

        static void Main()
        {
            Console.SetIn(new StreamReader("./input.txt"));
            var input = int.Parse(Console.ReadLine());
            var arr = new int[input];
            var procceed = true;

            for (int i = 0; i < input; i++)
            {
                var components = Console.ReadLine().Split(' ');
                var current = new Frame(int.Parse(components[0]), int.Parse(components[1]));

                for (int j = 0; j < frames.Count; j++)
                {
                    if (frames[j].X == current.X && frames[j].Y == current.Y)
                    {
                        arr[i] = arr[j];
                        procceed = false;

                        continue;
                    }
                }

                if (procceed)
                {
                    arr[i] = i;
                }
                procceed = true;

                frames.Add(current);
            }


            Array.Sort(arr);
            frames=frames.OrderBy(x => x.X).ThenBy(x => x.Y).ToList();

            PermuteWithRep(arr, 0, arr.Length);
            Console.WriteLine(permutations);
            Console.WriteLine(result.ToString().Substring(0,result.Length-1));
        }
        static void PermuteWithRep(int[] arr, int start, int n)
        {
            PrintArray(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteWithRep(arr, left + 1, n);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        private static void PrintArray(int[] arr)
        {
            permutations++;

            var index = -1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (frames[arr[i]].X != frames[arr[i]].Y)
                {
                    index = i;
                    if(frames[arr[i]].X > frames[arr[i]].Y)
                    {

                    }
                    break;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result.Append("("+frames[arr[i]].X+", "+ frames[arr[i]].Y+")");
                if (i != arr.Length - 1)
                {
                    result.Append(" | ");
                }
            }

            result.AppendLine();

            if (index != -1)
            {
                permutations++;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == index)
                    {
                        result.Append("(" + frames[arr[i]].Y + ", " + frames[arr[i]].X + ")");
                    }
                    else
                    {

                        result.Append("(" + frames[arr[i]].X + ", " + frames[arr[i]].Y + ")");
                    }

                    if (i != arr.Length - 1)
                    {
                        result.Append(" | ");
                    }
                }

                result.AppendLine();
            }
        }
    }
}
