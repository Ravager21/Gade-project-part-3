using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class SwampCreatures : Enemy
    {
        //hp is left as an optional parameter so that when reloading the game the swampcreature can have the correct health not full health
        public SwampCreatures(int x, int y, int Hp = 10) : base(x, y, Hp, 10, 1)
        {
            weaponEquiped = new MeleeWeapon(MeleeWeapon.Types.Dagger);
            goldPurse = 1;
        }

        //Swamp Creature, an enemy

        //Movement for the swamp creature, it has been edited because it was not working properly for the previous tasks 
        public override MovementEnum ReturnMove(MovementEnum movement)
        {
            bool availablePath = false;
            for (int i = 0; i < vision.Length; i++)
            {
                if (vision[i] is EmptyTile or Item)
                {
                    availablePath = true;
                    break;
                }
            }
            if (!availablePath) return MovementEnum.NoMovement;

            bool loop;
            int dir;
            do
            {
                dir = num.Next(4);
                if (vision[dir] is EmptyTile or Item) loop = false;
                else loop = true;
            } while (loop);

            return (MovementEnum)dir;
        }
    }
}
