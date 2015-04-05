using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEcosystem;

namespace AcademyEcosystem
{
    class Zombie : Animal
    {
        public Zombie(string name, Point location)
            : base(name, location, 1)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            this.IsAlive = true;
            return 10;
        }
    }
}
