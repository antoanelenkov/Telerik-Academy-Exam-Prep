
namespace AcademyEcosystem
{
    using System;
    using System.Linq;


    public class Lion : Animal, ICarnivore, IOrganism
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {
        }

        public int TryEatAnimal(Animal animal)
        {

            if (animal != null)
            {
                if (animal.IsAlive && animal.Size <= this.Size * 2)
                {
                    this.Size += 1;
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
