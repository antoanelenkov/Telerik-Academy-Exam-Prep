namespace Computers
{
    using Components.CPUs;
    using RandomGenerators;
    using System;

    class Cpu32:Cpu
    {
        internal Cpu32(byte numberOfCores,Ram ram,VideoCard videoCard,IRandomGenerator randomGenerator):base(numberOfCores,ram,videoCard,randomGenerator)
        {
            this.numberOfCores = numberOfCores;
            this.ram = ram;
            this.videoCard = videoCard;
            this.randomGenerator = randomGenerator;
        }

        public override void SquareGeneratedRandomNumber()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 500)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = (int)Math.Pow(data, 2);

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }
    }
}
