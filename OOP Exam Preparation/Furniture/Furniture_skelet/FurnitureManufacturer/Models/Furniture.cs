using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture:IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;
        private string material;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Height = height;
            this.Material = materialType.ToString();
        }
        public string Model
        {
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value of the model cannot be null or empty");
                }
                else
                {
                    this.model = value;
                }
            }
            get
            {
                return this.model;
            }
        }

        public string Material
        {
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value of the material cannot be null or empty");
                }
                this.material = value;
            }
            get { return this.material; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("The value of the price cannot be null or empty");
                }
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The price cannot be non-negative value");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("The value of the heigth cannot be null or empty");
                }
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height cannot be non-negative value");
                }
                else
                {
                    this.height = value;
                }
            }
        }


        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material,  this.Price,this.Height);
        }


    }
}
