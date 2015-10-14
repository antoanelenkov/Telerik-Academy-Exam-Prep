using Computers.Components.Contracts;

namespace Computers
{
    internal class Ram : IRam
    {
        private int memory;

        internal Ram(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; set; }

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