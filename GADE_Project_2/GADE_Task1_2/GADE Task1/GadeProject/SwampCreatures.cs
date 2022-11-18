using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class SwampCreatures : Enemy
    {
        //Swamp Creature, an enemy
        public SwampCreatures(int x, int y, Tile.TileType type) : base (x, y, 1, TileType.Enemy, 10, 10, "SC")
        {
            this.Hp = 10;
            this.maxHp = 10;
            this.Damage = 1;

        }
        //Movement for the swamp creature 
        public override MovementEnum ReturnMove(MovementEnum movement)
        {
            int space = 0;
            int RandMovement = num.Next(5);
            movement = (MovementEnum)RandMovement;
            //if(space == 0)
            //{
            //    return MovementEnum.NoMovement;
            //}

            //while(space > 0)
            //{
                if (movement == MovementEnum.Up)
                {
                    if (this.Vision[0] is EmptyTile)
                    {
                        return MovementEnum.Up;
                    }

                }
                if (movement == MovementEnum.Down)
                {
                    if (this.Vision[1] is EmptyTile)
                    {
                        return MovementEnum.Down;
                    }
                }

                if (movement == MovementEnum.Left)
                {
                    if (this.Vision[2] is EmptyTile)
                    {
                        return MovementEnum.Left;
                    }
                }

                if (movement == MovementEnum.Right)
                {
                    if (this.Vision[2] is EmptyTile)
                    {
                        return MovementEnum.Right;
                    }
                }
                movement = (MovementEnum)(num.Next(4) + 1);
            //}
            return MovementEnum.NoMovement;
        }
    }
}
