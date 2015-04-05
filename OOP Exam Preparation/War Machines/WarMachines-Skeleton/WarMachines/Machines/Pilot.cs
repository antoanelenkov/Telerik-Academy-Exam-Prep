using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Pilot:IPilot
    {
        private string name;
        private IList<IMachine> listWithMachines = new List<IMachine>();

        public Pilot(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value must not be null or empty");
                }
                this.name = value;
            }
            get { return this.name; }
        }

        public void AddMachine(IMachine machine)
        {
            listWithMachines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.Append(String.Format("{0} - {1} {2}", this.Name,
                this.listWithMachines.Count > 0 ? listWithMachines.Count.ToString() : "no",
                this.listWithMachines.Count != 1 ? "machines" : "machine")); 

            if(listWithMachines.Count>0)
            {
                sb.AppendLine();
                var collection=listWithMachines.OrderBy(x=>x.HealthPoints).ThenBy(x=>x.Name);
                foreach (var item in collection)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
