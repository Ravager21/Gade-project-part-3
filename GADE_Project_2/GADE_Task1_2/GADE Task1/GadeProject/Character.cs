using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    //Character class
    public abstract class Character : Tile
    {
        int PlayerDamage = 2;
        public Tile[] Vision = new Tile[4];
        //class constrcutror 
        protected Character(int x, int y, TileType type) : base(x, y, type)
        {

        }

        protected int Hp { set; get; }
        public int HP { set { HP = value; } get { return Hp; } }
        protected int maxHp {set; get;}
        protected int Damage { set; get; }
        public int DAMAGE { set { DAMAGE = value; } get { return Damage; } }
        public int GoldPurse;
        
        
        public enum MovementEnum
        {
            NoMovement,
            Up,
            Down,
            Right,
            Left

        }
        //attack method, this is for attacking the enemy
        public virtual void Attack(Character Target) 
        {
           Target.Hp  = Target.Hp - 2/*this.Damage*/;
            
        }

        public bool IsDead()
        {
            if(Hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    //checking the range method 
       public virtual bool CheckRange(Character CharacterTarget)
        {
            if(DistanceTo(CharacterTarget) == 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        
        private int DistanceTo(Character Tar)
        {
            int distance = Math.Abs((Tar.X - this.X) + (Tar.Y - this.Y));
            
            
            return distance;
        }
        //Movement method, making sure the character is able to move
        public void Move(MovementEnum move)
        {
            if(move == MovementEnum.NoMovement)
            {
                
            }
            else if(move == MovementEnum.Up && Vision[0] is EmptyTile)
            {
                this.y--;
            }
            else if (move == MovementEnum.Down && Vision[1] is EmptyTile)
            {
                this.y++;
            }
            else if(move == MovementEnum.Right && Vision[2] is EmptyTile)
            {
                this.x++;
            }
            else if(move == MovementEnum.Left && Vision[3] is EmptyTile)
            {
                this.x--;
            }
        }
        
        public abstract MovementEnum ReturnMove(MovementEnum move);

       
        public override string ToString()
        {
            return base.ToString();
        }

        public void Pickup(Item i)
        {
            if(i is Gold)
            {
                Gold gg = new Gold(X,Y,TileType.Gold);
                GoldPurse += gg.GoldDropAmount;
            }
            
        }


    }
}

