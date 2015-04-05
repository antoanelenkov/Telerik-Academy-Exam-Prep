using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class Chair:Furniture,IFurniture,IChair
    {
        private int numberOfLegs;

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model,materialType,price,height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            private set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("The value of the chair number of legs cannot be null or empty");
                }
                this.numberOfLegs = value;
            }
            get 
            {
                return this.numberOfLegs;
            }
        }

        public override string ToString()
        {
            var chairDescription = new StringBuilder();
            string baseDescription = base.ToString();
            chairDescription.Append(baseDescription)
              .Append(string.Format(", Legs: {0}", this.NumberOfLegs));
            return chairDescription.ToString();
        }

    }
}
