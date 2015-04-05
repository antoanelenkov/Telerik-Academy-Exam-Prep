using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defenePoints;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Element must not be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Element must not be null");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Element must not be null");
                }
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Element must not be null");
                }
                this.attackPoints = value;
            }
            get
            {
                return this.attackPoints;
            }
        }

        public double DefensePoints
        {
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Element must not be null");
                }
                this.defenePoints = value;
            }
            get
            {
                return this.defenePoints;
            }
        }

        public IList<string> Targets
        {
            get { return new List<string>(this.targets); }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public  string ToString()
        {
            var sb = new StringBuilder();
            sb = sb.Append(String.Format("- {6}{0} *Type: {1}{0} *Health: {2}{0} *Attack: {3}{0} *Defense: {4}{0} *Targets: {5}",
                Environment.NewLine,
                this.GetType().Name,
                this.HealthPoints,
                this.AttackPoints,
                this.DefensePoints,
                (this.Targets.Count == 0 ? "None" : string.Join(", ", this.targets)),
                this.Name));
            return sb.ToString();
 
        }
    }
}
