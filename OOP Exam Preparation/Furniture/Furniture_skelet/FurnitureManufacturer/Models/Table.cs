using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class Table:Furniture,IFurniture,ITable
    {
        private decimal length;
        private decimal width;


        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType,price,height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            private set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("The value of the table length cannot be null or empty");
                }
                this.length = value;
            }
            get
            {
                return this.length;
            }
                
        }

        public decimal Width
        {
            private set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("The value of the table width cannot be null or empty");
                }
                this.width = value;
            }
            get
            {
                return this.width;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Height;
            }
        }

        public override string ToString()
        {
            var tableDescription = new StringBuilder();
            string baseDescription = base.ToString();
            tableDescription.Append(baseDescription)
              .Append(string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area));
            return tableDescription.ToString();
        }
    }
}
