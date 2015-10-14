namespace Computers
{
    using System;

    class Cpu
    {
        private readonly byte numberOfBits;

        private readonly Ram ram;

        private readonly VideoCard videoCard;

        static readonly Random Random = new Random();

        internal Cpu(byte numberOfCores, byte numberOfBits, Ram ram, VideoCard videoCard)
        {
            this.numberOfBits = numberOfBits;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
            this.videoCard = videoCard;
        }

        byte NumberOfCores { get; set; }

        internal void SquareNumber()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 500 && numberOfBits == 32)
            {
                this.videoCard.Draw("Number too high.");
            }
            else if (data > 1000 && numberOfBits == 64)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = (int)Math.Pow(data, 2);

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        internal void rand(int a, int b)
        {
            int randomNumber;

            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= a && randomNumber <= b));

            this.ram.SaveValue(randomNumber);
        }
    }
}
