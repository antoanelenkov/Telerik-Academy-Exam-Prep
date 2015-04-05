using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank:Machine,ITank
    {
        private const double InitalHealthPoints=100;
        private const double changeDefencePoints = 30;
        private const double changeAttackPoints = 40; 
        private bool defenceMode;


        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitalHealthPoints)
        {
            this.defenceMode = true;
            this.AttackPoints = this.AttackPoints - changeAttackPoints;
            this.DefensePoints = this.DefensePoints + changeDefencePoints;
        }
        public bool DefenseMode
        {
             get 
             {
                 if (defenceMode)
                 {

                 }
              
                 return this.defenceMode;
             }
        }

        public void ToggleDefenseMode()
        {
            this.defenceMode = !this.defenceMode;
            if (this.defenceMode)
            {
                this.AttackPoints = this.AttackPoints - changeAttackPoints;
                this.DefensePoints = this.DefensePoints + changeDefencePoints;
            }
            else
            {
                this.AttackPoints = this.AttackPoints + changeAttackPoints;
                this.DefensePoints = this.DefensePoints - changeDefencePoints;
            }

        }

        public string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString()).
                AppendLine(String.Format(" *Defense: {0}", this.DefenseMode == true ? "ON" : "OFF"));
            return sb.ToString().TrimEnd();
        }
    }
}
