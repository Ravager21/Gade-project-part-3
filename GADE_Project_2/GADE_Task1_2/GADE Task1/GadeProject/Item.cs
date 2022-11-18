using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    public abstract class Item : Tile
    {

        
        public Item(int x, int y, TileType type) : base(x, y, type)
        {
        }


        public abstract override string ToString();
        
        
        
            
    }

    
}
