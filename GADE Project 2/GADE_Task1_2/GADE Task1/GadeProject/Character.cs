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
        //protected member variables
        protected int hp;
        protected int maxHp;
        protected int dmg;
        protected Tile[] vision;
        protected int goldPurse;
        protected Weapon? weaponEquiped;

        //class constrcutror 
        protected Character(int x, int y, int hp, int maxHp, int dmg) : base(x, y)
        {
            this.hp = hp;
            this.maxHp = maxHp;
            this.dmg = dmg;
            vision = new Tile[4];
        }

        //properties
        public Tile[] Vision { get { return vision; } set { vision = value; } }
        public int HP { get { return hp; } set { hp = value; } }
        public int MaxHP { get { return maxHp; } set { maxHp = value; } }
        public int Damage { get { return dmg; } set { dmg = value; } }
        public int GoldPurse { get { return goldPurse; } set { goldPurse = value; } }
        public Weapon WeaponEquiped { get { return weaponEquiped; } }
        
        public enum MovementEnum
        {
            Up,
            Down,
            Left,
            Right,
            NoMovement

        }
        //attack method, this is for attacking the enemy
        public virtual void Attack(Character Target) 
        {
            if (!CheckRange(Target)) return;

            //removes targets health by the damage value
            if (weaponEquiped is null) Target.HP -= this.dmg;
            else Target.HP -= weaponEquiped.Damage;
        }

        public bool IsDead()
        {
            //checks if the current character is dead
            if(this.hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //checking the range
        public virtual bool CheckRange(Character CharacterTarget)
        {
            if (DistanceTo(CharacterTarget) <= ((weaponEquiped is null) ? 1 : weaponEquiped.Range))
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
            return Math.Abs(Tar.X - this.x) + Math.Abs(Tar.Y - this.y);
        }


        public void Move(MovementEnum move)
        {
            switch (move)
            {
                case MovementEnum.Up:
                    y--;
                    break;
                case MovementEnum.Down:
                    y++;
                    break;
                case MovementEnum.Left:
                    x--;
                    break;
                case MovementEnum.Right:
                    x++;
                    break;
                case MovementEnum.NoMovement:
                    break;
            }
            
        }

        public void Pickup(Item i)
        {
            if(i is Gold gg)
            {
                goldPurse += gg.GoldDropAmount;
            }
            else //weapon
            {
                Equip((Weapon)i);
            }   
        }

        private void Equip(Weapon w)
        {
            weaponEquiped = w;
        }
        
        public void Loot(Character killedCharacter)
        {
            goldPurse += killedCharacter.GoldPurse;
            if (weaponEquiped is null && this is not Mage)
            {
                weaponEquiped = killedCharacter.weaponEquiped;
            }
        }

        //abstract methods
        public abstract MovementEnum ReturnMove(MovementEnum move);
        public abstract override string ToString();


    }
}

