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
        public Enemy(int x, int y, int Damage,TileType type, int Hp, int maxHp, string symbol) : base (x, y, type)
        {
            this.Hp = 10;
            this.Damage = 1;
            this.maxHp = 10;
        }
        protected int Hp { set; get; }
        
        protected int maxHp { set; get; }
        protected int Damage { set; get; }

        public override string ToString()
        {
            return Type.ToString() + " at " + "[" + x.ToString() + "," +
                y.ToString() + "] (Damage: " + Damage.ToString() + ")" + " HP: " + Hp.ToString();
        }

    }
}
