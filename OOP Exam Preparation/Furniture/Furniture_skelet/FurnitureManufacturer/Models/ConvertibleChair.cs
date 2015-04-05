using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IChair, IConvertibleChair
    {
        public const decimal ConvertedHeight=0.10m;
        public readonly decimal NormalHeight;
        private bool isConverted;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.NormalHeight = height;
        }

        public bool IsConverted
        {
            private set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("The value of the table state cannot be null or empty");
                }
                this.isConverted = value;
            }
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            if(this.IsConverted==true)
            {
                this.IsConverted = false;
                this.Height = NormalHeight;
            }
            else
            {
                this.IsConverted = true;
                this.Height = ConvertedHeight;
            }
        }


        public override string ToString()
        {
            var convChairDescription = new StringBuilder();
            string baseDescription = base.ToString();
            convChairDescription.Append(baseDescription)
              .Append(string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal"));
            return convChairDescription.ToString();
        }
    }
}
