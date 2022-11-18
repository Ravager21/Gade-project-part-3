using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    //Tile class and tiletype created 
    public abstract class Tile
    {
        protected int x, y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public enum TileType
        {
            Hero,
            Enemy,
            Gold,
            Weapon,
            Obstacle,
            Empty

        }

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
