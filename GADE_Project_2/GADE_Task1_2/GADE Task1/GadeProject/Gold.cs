using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Gold : Item
    {
        // Compare with other people work.
        private int GoldDrop;
        private Random Gnum = new Random();
        
        public int GoldDropAmount { get { return GoldDrop; } }
        
        
        

        public Gold(int x, int y, TileType type) : base(x, y, type)
        {
            
            GoldDrop = Gnum.Next(1, 6);

        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

    }
}
