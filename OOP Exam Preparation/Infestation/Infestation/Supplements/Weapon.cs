using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    class Weapon:ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public Weapon()
        {
            this.powerEffect = 0;
            this.healthEffect = 0;
            this.aggressionEffect = 0;
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Equals(new WeaponrySkill().GetType()))
            {
                powerEffect = 10;
                aggressionEffect = 3;
            }
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
