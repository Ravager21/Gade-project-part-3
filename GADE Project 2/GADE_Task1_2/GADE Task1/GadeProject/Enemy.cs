using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    public abstract class Enemy : Character 
    {
        protected Random num = new Random();
        //Enemy constuctor
        public Enemy(int x, int y, int Hp, int maxHp, int dmg) : base(x, y, Hp, maxHp, dmg)
        {

        }

        public override string ToString()
        {
            if (weaponEquiped is null)
            {
                switch (this)
                {
                    case SwampCreatures:
                        return $"Bare Handed: Swamp Creature ({hp}/{maxHp}HP) at [{x}, {y}] ({dmg})";
                    case Mage:
                        return $"Bare Handed: Mage ({hp}/{maxHp}HP) at [{x}, {y}] ({dmg})";
                    case Leader:
                        return $"Bare Handed: Leader ({hp}/{maxHp}HP) at [{x}, {y}] ({dmg})";
                    default:
                        return $"This is unreachable but the ToString thinks otherwise";
                }
            }
            else
            {
                switch (this)
                {
                    case SwampCreatures:
                        return $"Equiped: Swamp Creature ({hp}/{maxHp}HP) at [{x}, {y}] with {weaponEquiped.WeaponType} ({weaponEquiped.Durability} x {weaponEquiped.Damage})";
                    case Mage:
                        return $"Equiped: Mage ({hp}/{maxHp}HP) at [{x}, {y}] with {weaponEquiped.WeaponType} ({weaponEquiped.Durability} x {weaponEquiped.Damage})";
                    case Leader:
                        return $"Equiped: Leader ({hp}/{maxHp}HP) at [{x}, {y}] with {weaponEquiped.WeaponType} ({weaponEquiped.Durability} x {weaponEquiped.Damage})";
                    default:
                        return $"This is unreachable but the ToString thinks otherwise";
                }
            }
            
        }

    }
}
