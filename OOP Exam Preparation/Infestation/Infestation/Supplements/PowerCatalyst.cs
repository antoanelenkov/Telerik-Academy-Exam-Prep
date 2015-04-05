using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    class PowerCatalyst:ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public PowerCatalyst()
        {
            this.powerEffect = 3;
            this.healthEffect = 0;
            this.aggressionEffect =0;
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            //no reaction
        }

        public int PowerEffect
        {
            get 
            {
                return this.powerEffect;
            }
        }

        public int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
        }

        public int AggressionEffect
        {
            get
            {
                return this.aggressionEffect;
            }
        }
    }
}
