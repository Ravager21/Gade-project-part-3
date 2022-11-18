using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Leader : Enemy
    {
        private Tile? target;

        //the default 20 in the optional hp paramater is so that when loading the game, the hp can be set to where it was.
        public Leader(int x, int y, int Hp = 20) : base(x, y, Hp, 20, 2)
        {
            weaponEquiped = new MeleeWeapon(MeleeWeapon.Types.Longsword);
            goldPurse = 2;
        }

        public Tile? Target { get { return target; } set { target = value; } }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            // The leader will move first on the x, then the y towards the hero, if niether are available, he will move in a random direction.
            
            //doesnt move without a target
            if (target is null) return MovementEnum.NoMovement;
            
            //positive if must move left, negative if right, 0 is the x values are equal. 
            int xMovement = Math.Sign(x - target.X);
            switch (xMovement)
            {
                case -1: //moving right
                    if (vision[(int)MovementEnum.Right] is EmptyTile or Item)
                    {
                        return MovementEnum.Right;
                    }
                    break;
                case 1: //moving left
                    if (vision[(int)MovementEnum.Left] is EmptyTile or Item)
                    {
                        return MovementEnum.Left;
                    }
                    break;
            }
            //negative is down, positive is up
            int yMovement = Math.Sign(y - target.Y);
            switch (yMovement)
            {
                case -1: //moving down
                    if (vision[(int)MovementEnum.Down] is EmptyTile or Item)
                    {
                        return MovementEnum.Down;
                    }
                    break;
                case 1: //moving up
                    if (vision[(int)MovementEnum.Up] is EmptyTile or Item)
                    {
                        return MovementEnum.Up;
                    }
                    break;
            }

            //random move
            bool moveAvailable = false;
            for (int i = 0; i < vision.Length; i++)
            {
                if (vision[i] is EmptyTile or Item)
                {
                    moveAvailable = true;
                    break;
                }
            }
            if (!moveAvailable) return MovementEnum.NoMovement;


            int dir;
            bool loop;
            do
            {
                dir = num.Next(4);

                if (vision[dir] is EmptyTile or Item)
                {
                    loop = false;
                }
                else loop = true;
            } while (loop);
            
            return (MovementEnum)dir;
        }
    }
}
