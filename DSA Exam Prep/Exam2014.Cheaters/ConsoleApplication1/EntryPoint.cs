namespace _01.Elections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class EntryPoint
    {
        static void Main()
        {
            var seats = int.Parse(Console.ReadLine());
            var parties = int.Parse(Console.ReadLine());
            var partiesSeats = new int[parties];
            var resultSeats = new int[3];

            for (int i = 0; i < parties; i++)
            {
                partiesSeats[i] = int.Parse(Console.ReadLine());
            }

            var subset = SubSetsOf(partiesSeats);
            var count = 0;
            foreach (var set in subset)
            {
                var sum = 0;
                foreach (var item in set)
                {
                    sum += item;
                    if (sum >= seats)
                    {
                        count++;
                        break;
                    }
                }

            }

            Console.WriteLine(count);
        }

        public static IEnumerable<IEnumerable<T>> SubSetsOf<T>(IEnumerable<T> source)
        {
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);

            var element = source.Take(1);

            var haveNots = SubSetsOf(source.Skip(1));
            var haves = haveNots.Select(set => element.Concat(set));

            return haves.Concat(haveNots);
        }
    }
}
