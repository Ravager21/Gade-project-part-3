using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    public abstract class Weapon : Item
    {
        protected int damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected string weaponType = "";

        public Weapon(int x = -1, int y = -1) : base(x, y) //the default -1 implies its not on the map
        {

        }

        public int Damage { get { return damage; } set { damage = value; } }
        public virtual int Range { get { return range; } set { range = value; } }
        public int Durability { get { return durability; } set { durability = value; } }
        public int Cost { get { return cost; } set { cost = value; } }
        public string WeaponType { get { return weaponType; } set { weaponType = value; } }

        public override abstract string ToString();
    }
}
