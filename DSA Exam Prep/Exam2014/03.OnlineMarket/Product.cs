using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OnlineMarket
{
    class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public override int GetHashCode()
        {
            return 23 + this.Name.GetHashCode() >> 17 ^
                  (23 + this.Price.GetHashCode() >> 17 ^
                   (23 + this.Type.GetHashCode() >> 17));
        }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return this.Name.Equals(product.Name);
        }

        public int CompareTo(Product other)
        {
            if (this.Price.CompareTo(other.Price) != 0)
            {
                return this.Price.CompareTo(other.Price);
            }
            else
            {
                return this.Name.CompareTo(other.Name) == 0 ? this.Type.CompareTo(other.Type) : this.Name.CompareTo(other.Name);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
