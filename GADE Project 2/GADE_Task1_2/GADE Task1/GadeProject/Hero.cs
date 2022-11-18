using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Hero : Character
    {
        //Hero constructor
        public Hero(int x, int y, int hp, int maxHp) : base(x, y, hp, maxHp, 2)
        {
            goldPurse = 0;
        }


        //Hero movement
        public override MovementEnum ReturnMove(MovementEnum HeroMove)
        {
            if (HeroMove == MovementEnum.Up)
            {
                if (this.Vision[0] is EmptyTile or Item)
                {
                    return MovementEnum.Up;
                }
            }
            if (HeroMove == MovementEnum.Down)
            {
                if (this.Vision[1] is EmptyTile or Item)
                {
                    return MovementEnum.Down;
                }
            }
            if (HeroMove == MovementEnum.Left)
            {
                if (this.Vision[2] is EmptyTile or Item)
                {
                    return MovementEnum.Left;
                }
            }
            if (HeroMove == MovementEnum.Right)
            {
                if (this.Vision[3] is EmptyTile or Item)
                {
                    return MovementEnum.Right;
                }
            }
            return MovementEnum.NoMovement;
        }
        //the Hero's toString method has been changed fixed and should work
        public override string ToString()
        {
            if (weaponEquiped is null)
            {
                return $"Player Stats: {Environment.NewLine}HP:{hp}/{maxHp} {Environment.NewLine}Current weapon: Bare Hands {Environment.NewLine}Weapon range: 1 {Environment.NewLine}Weapon damage: {dmg} {Environment.NewLine}[{x}, {y}]{Environment.NewLine}Gold Amount: {goldPurse}";
            }
            else
            {
                return $"Player Stats: {Environment.NewLine}HP:{hp}/{maxHp} {Environment.NewLine}Current weapon: {weaponEquiped.WeaponType} {Environment.NewLine}Weapon range: {weaponEquiped.Range} {Environment.NewLine}Weapon damage: {weaponEquiped.Damage} {Environment.NewLine}Weapon Durability: {weaponEquiped.Durability} {Environment.NewLine}[{x}, {y}]{Environment.NewLine}Gold Amount: {goldPurse}";

            }
        }
    }
}
