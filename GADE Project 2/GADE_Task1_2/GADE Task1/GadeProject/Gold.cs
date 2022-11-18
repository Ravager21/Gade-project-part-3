using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Gold : Item
    {
        private int GoldDrop;
        private Random Gnum = new Random();
        
        public Gold(int x, int y) : base(x, y)
        {
            GoldDrop = Gnum.Next(1, 6);
        }

        //the reason for the setter is so that when the game loads from save the gold can be redefined.
        public int GoldDropAmount { get { return GoldDrop; } set { GoldDrop = value; } }
        
        public override string ToString()
        {
            return "Gold";
        }

    }
}
