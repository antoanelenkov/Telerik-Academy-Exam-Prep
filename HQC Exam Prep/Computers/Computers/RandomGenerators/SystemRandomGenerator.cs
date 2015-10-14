namespace Computers.RandomGenerators
{
    using System;


    class SystemRandomGenerator : IRandomGenerator
    {
        private Random randomGenerator = new Random();

        public int GetRandomNumberInRange(int minValue, int maxValue)
        {
            return randomGenerator.Next(minValue, maxValue);
        }
    }
}
