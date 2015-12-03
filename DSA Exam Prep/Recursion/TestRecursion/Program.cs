using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRecursion
{
    class Program
    {
        //private ulong result = 1;

        static void Main(string[] args)
        {
            Console.WriteLine(SumAndProduct(2, 2));
            Console.WriteLine(Factorial(3));
            Console.WriteLine(Fibbonaci(6));
        }

        static ulong Factorial(ulong n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        // 1. fac(3)=3*fac(2);
        //2. fac(2)=2*fac(1);
        //3. fac(1)=1;


        static ulong Fibbonaci(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 1;
            }
  
            return Fibbonaci(n - 1) + Fibbonaci(n - 2);
        }


        static ulong SumAndProduct(ulong n, ulong b)
        {
            return (n + b) * Product(n, b);
        }

        static ulong Product(ulong n, ulong b)
        {
            return n * b;
        }
    }
}
