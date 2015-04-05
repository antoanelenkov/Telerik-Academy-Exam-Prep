using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter:Machine,IFighter,IMachine
    {
        private const double InitalHealthPoints=200;
        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defensePoints,bool stealthMode)
            : base(name, attackPoints, defensePoints, InitalHealthPoints)
        {

            this.stealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            stealthMode = !stealthMode;
        }



        public string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString()).
                Append(String.Format(" *Stealth: {0}",this.StealthMode==true?"ON":"OFF"));
            return sb.ToString().TrimEnd();
        }
    }
}
