using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class Company:ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string reg)
        {
            this.Name = name;
            this.RegistrationNumber = reg;
            this.Furnitures=new List<IFurniture>();
        }

        public string Name
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value of the name cannot be null or empty");
                }
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("The name of the company must be at least with five symbols.");
                }
                this.name = value;
            }
            get { return this.name; }
        }

        public string RegistrationNumber
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value of the name cannot be null or empty");
                }
                foreach (var item in value)
                {
                    if (!char.IsDigit(item))
                    {
                        throw new ArgumentException("The registration number must consist only of digits");
                    }
                }
                this.registrationNumber = value;
            }
            get { return this.registrationNumber; }
        }

        public ICollection<IFurniture> Furnitures
        {
            private set
            {
                this.furnitures = value;
            }
            get
            {
                return new List<IFurniture>(furnitures);
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var item in this.furnitures)
            {
                if (item.Model.ToUpper() == model.ToUpper())
                {
                    return item;
                }
            }
            return null;
        }

        public string Catalog()
        {
            var catalog = new StringBuilder();
            catalog.AppendLine(String.Format("{0} - {1} - {2} {3}",
                this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));
            foreach (var item in this.Furnitures.OrderBy(x=>x.Price).ThenBy(x=>x.Model))
            {
                catalog.AppendLine(item.ToString());
            }
            return catalog.ToString().TrimEnd();
        }
    }
}
