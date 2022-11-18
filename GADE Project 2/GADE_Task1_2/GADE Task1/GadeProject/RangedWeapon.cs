using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class RangedWeapon : Weapon
    {
        public enum Types
        {
            Rifle,
            Longbow
        }
        //Types of ranged weapons that will be spawned 
        public RangedWeapon(Types weaponType, int x = -1, int y = -1) : base(x, y)
        {
            switch (weaponType)
            {
                case Types.Rifle:
                    this.weaponType = "Rifle";
                    durability = 3;
                    range = 3;
                    damage = 5;
                    cost = 7;
                    break;
                case Types.Longbow:
                    this.weaponType = "Longbow";
                    durability = 4;
                    range = 2;
                    damage = 4;
                    cost = 6;
                    break;
            }
        }

        public RangedWeapon(Types weaponType, int durability)
        {
            switch (weaponType)
            {
                case Types.Rifle:
                    this.weaponType = "Rifle";
                    this.durability = durability;
                    range = 3;
                    damage = 5;
                    cost = 7;
                    break;
                case Types.Longbow:
                    this.weaponType = "Longbow";
                    this.durability = durability;
                    range = 2;
                    damage = 4;
                    cost = 6;
                    break;
            }
        }

        public override int Range { get { return base.range; } }

        public override string ToString()
        {
            return weaponType;
        }
    }
}
