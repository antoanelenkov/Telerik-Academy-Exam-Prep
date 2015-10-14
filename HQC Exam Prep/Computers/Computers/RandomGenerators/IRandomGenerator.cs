using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.RandomGenerators
{
    interface IRandomGenerator
    {
        int GetRandomNumberInRange(int lowerBound, int upperBound);
    }
}
