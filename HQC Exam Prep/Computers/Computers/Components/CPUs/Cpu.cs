using Computers.Components.Contracts;
using Computers.RandomGenerators;
using System;

namespace Computers.Components.CPUs
{
    internal abstract class Cpu:ICpu
    {
        protected  IRam ram;
        protected  VideoCard videoCard;
        protected IRandomGenerator randomGenerator;
        protected byte numberOfCores;

        protected Cpu(byte numberOfCores, IRam ram, VideoCard videoCard, IRandomGenerator randomGenerator)
        {
            this.ram = ram;
            this.numberOfCores = numberOfCores;
            this.videoCard = videoCard;
            this.randomGenerator = randomGenerator;
        }

        public abstract void SquareGeneratedRandomNumber();

        public void SaveRandomNumberInRange(int a, int b)
        {
            int randomNumber = this.randomGenerator.GetRandomNumberInRange(a, b);

            this.ram.SaveValue(randomNumber);
        }
    }
}

