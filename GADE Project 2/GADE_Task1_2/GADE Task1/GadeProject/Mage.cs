using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
     class Mage : Enemy 
    {
        //The mage takes in the optional hp paramater so that when the game is loaded from save, the created mages have the correct Hp that can be set when they're created.
        public Mage(int x, int y, int Hp = 5) : base(x, y, Hp, 5, 5)
        {
            goldPurse = 3;
        }

        public override bool CheckRange(Character CharacterTarget)
        {
            return (Math.Abs(CharacterTarget.X - x) <= 1 && Math.Abs(CharacterTarget.Y - Y) <= 1);
        }

        public override MovementEnum ReturnMove(MovementEnum move = MovementEnum.NoMovement)
        {
            return MovementEnum.NoMovement;
        }
    }
}
