using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Hero : Character
    {
        public Gold gg;
        //Hero constructor
        public Hero(int x, int y,Tile.TileType type) : base(x, y, type)
        {
            this.Hp = 30;
            this.maxHp = 30;
            this.Damage = 2;
        }
        //Hero movement
        public override MovementEnum ReturnMove(MovementEnum HeroMove)
        {
            if (HeroMove == MovementEnum.Up)
            {
                if (this.Vision[0] is EmptyTile)
                {
                    return MovementEnum.Up;
                }

            }
            if (HeroMove == MovementEnum.Down)
            {
                if (this.Vision[1] is EmptyTile)
                {
                    return MovementEnum.Down;
                }
            }

            if (HeroMove == MovementEnum.Left)
            {
                if (this.Vision[2] is EmptyTile)
                {
                    return MovementEnum.Left;
                }
            }

            if (HeroMove == MovementEnum.Right)
            {
                if (this.Vision[3] is EmptyTile)
                {
                    return MovementEnum.Right;
                }
            }
            return MovementEnum.NoMovement;
        }
        public override string ToString()
        {

            return "Player stats: \n" +
                "HP: " + Hp.ToString() +
                "\n Damage: " + Damage.ToString()
                + " Hero is at: " + "[" + x.ToString() + "," + y.ToString() + "]"
                + "Gold amount: "; 
        }
    }
}
