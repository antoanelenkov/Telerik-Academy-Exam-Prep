using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class AdjustableChair:Chair,IFurniture,IAdjustableChair,IChair
    {
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }
        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
