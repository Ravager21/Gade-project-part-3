using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
     class Mage : Enemy 
    {
        public Mage(int x, int y, int Damage, TileType type, int Hp, int maxHp, string symbol) : base(x, y, Damage, type, Hp, maxHp, symbol)
        {
            Hp = 5;
            Damage = 5;
        }
        
        

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return 0;
        }
    }
}
