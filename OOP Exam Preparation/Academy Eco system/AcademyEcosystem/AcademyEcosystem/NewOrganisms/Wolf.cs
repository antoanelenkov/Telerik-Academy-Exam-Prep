using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyEcosystem;

namespace AcademyEcosystem
{
    class Wolf:Animal,ICarnivore
    {
        public Wolf(string name, Point location)
            :base(name,location,4)
        {
        }
        //TO-DO - check update


        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if ((animal.IsAlive && animal.State == AnimalState.Sleeping) || (animal.IsAlive && animal.Size <= this.Size))
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


    }
}
