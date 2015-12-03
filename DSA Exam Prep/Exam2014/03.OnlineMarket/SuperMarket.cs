using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OnlineMarket
{
    class SuperMarket
    {
        private SortedSet<Product> products;
        private HashSet<string> names;
        private IDictionary<string, ICollection<Product>> types;

        public SuperMarket()
        {
            this.products = new SortedSet<Product>();
            this.types = new Dictionary<string, ICollection<Product>>();
            this.names = new HashSet<string>();
        }

        public string Add(string name, double price, string type)
        {
            var productToAdd = new Product(name, price, type);
            var errorMessage = string.Format("Error: Product {0} already exists", productToAdd.Name);

            if (this.names.Contains(name))
            {
                return errorMessage;
            }
            if (products.Contains(productToAdd))
            {
                return errorMessage;
            }
            this.products.Add(productToAdd);
            this.names.Add(productToAdd.Name);

            if (!types.ContainsKey(productToAdd.Type))
            {
                types[productToAdd.Type] = new SortedSet<Product>();
            }
            types[productToAdd.Type].Add(productToAdd);

            return string.Format("Ok: Product {0} added successfully", productToAdd.Name);
        }

        internal string FilterByType(string v)
        {
            StringBuilder result = new StringBuilder();

            if (this.types.ContainsKey(v))
            {
                result.Append("Ok: ");
                var types = this.types[v].Take(10).ToList();
                foreach (var item in types)
                {
                    result.Append(item.ToString() + ", ");
                }
                result.Remove(result.Length - 2, 2);

                return result.ToString();
            }

            return string.Format("Error: Type {0} does not exists", v);
        }

        internal string Filter(double from=0, double to=double.MaxValue)
        {
            var fromProduct = new Product("random", from, "random");
            var toProduct = new Product("random", to, "random");

            var results = this.products.GetViewBetween(fromProduct, toProduct).Take(10).ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append("Ok: ");

            if (results.Count != 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    sb.Append(results[i].ToString() + ", ");
                }
                sb.Remove(sb.Length - 2, 2);

                return sb.ToString();
            }

            return sb.ToString();
        }

    }
}
