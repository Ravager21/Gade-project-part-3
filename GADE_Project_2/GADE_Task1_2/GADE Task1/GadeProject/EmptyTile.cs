using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class EmptyTile : Tile
    {
        //Empty tile dummy class
        public EmptyTile(int x, int y, TileType type) : base(x, y, type)
        {
        }
    }
}
