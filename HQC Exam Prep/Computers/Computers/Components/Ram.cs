namespace Computers
{
    class Ram
    {
        private int memory;

        internal Ram(int a)
        {
            this.Amount = a;
        }

        int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.memory = newValue;
        }

        public int LoadValue()
        {
            return this.memory;
        }
    }
}