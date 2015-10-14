namespace Computers
{
    class LaptopBattery
    {
        private const int DefaultCharge = 50;
        private const int MaxCharge = 100;
        private const int MinCharge = 0;

        internal LaptopBattery()
        {
            this.Percentage = DefaultCharge;
        }

        internal int Percentage { get; set; }

        internal void Charge(int percentage)
        {
            this.Percentage += percentage;

            if (Percentage > MaxCharge)
            {
                Percentage = MaxCharge;
            }

            if (Percentage < MinCharge)
            {
                Percentage = MinCharge;
            }
        }
    }
}
