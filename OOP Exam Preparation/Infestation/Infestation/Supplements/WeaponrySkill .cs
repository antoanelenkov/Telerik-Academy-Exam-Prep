using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation.Supplements
{
    class WeaponrySkill : ISupplement
    {
        private const int InitalPowerEffect = 0;
        private const int InitalHealthEffect = 0;
        private const int InitalAggressionEffect = 0;



        public void ReactTo(ISupplement otherSupplement)
        {
            //no reaction
        }

        public int PowerEffect
        {
            get
            {
                return WeaponrySkill.InitalPowerEffect;
            }
        }

        public int HealthEffect
        {
            get
            {
                return WeaponrySkill.InitalHealthEffect;
            }
        }

        public int AggressionEffect
        {
            get
            {
                return WeaponrySkill.InitalAggressionEffect;
            }
        }
    }
}
