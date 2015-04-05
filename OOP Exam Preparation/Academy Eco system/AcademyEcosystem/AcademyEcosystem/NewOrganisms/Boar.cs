using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEcosystem;

namespace AcademyEcosystem
{
    class Boar : Animal, ICarnivore, IHerbivore
    {
        private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, 4)
        {
            this.biteSize = 2;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.IsAlive && animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size += 1;
                return p.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }

    }
}
