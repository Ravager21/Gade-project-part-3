using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class MeleeWeapon : Weapon
    {
        public enum Types
        {
            Dagger,
            Longsword
        }
        //Types of melee weapons that will be spawned 
        public MeleeWeapon(Types weaponType, int x = -1, int y = -1) : base(x, y)
        {
            switch (weaponType)
            {
                case Types.Dagger:
                    this.weaponType = "Dagger";
                    durability = 10;
                    damage = 3;
                    cost = 3;
                    break;
                case Types.Longsword:
                    this.weaponType = "LongSword";
                    durability = 6;
                    damage = 4;
                    cost = 5;
                    break;
            }
        }

        public override int Range { get { return 1; } }

        public override string ToString()
        {
            return weaponType;
        }
    }
}
