using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    class AggressionCatalyst:ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public AggressionCatalyst()
        {
            this.powerEffect = 0;
            this.healthEffect = 0;
            this.aggressionEffect = 3;
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
