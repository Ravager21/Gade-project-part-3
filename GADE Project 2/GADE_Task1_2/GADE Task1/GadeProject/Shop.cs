using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GadeProject
{
    internal class Shop
    {
        private Weapon[] weapons;
        private Random random;
        private Character buyer;

        public Shop(Character buyer)
        {
            this.buyer = buyer;

            random = new Random();
            weapons = new Weapon[3];
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }
        //types of weapons that will be spawned on the map
        private Weapon RandomWeapon()
        {
            int choice = random.Next(4);
            switch (choice)
            {
                case 0:
                    return new MeleeWeapon(MeleeWeapon.Types.Dagger);
                case 1:
                    return new MeleeWeapon(MeleeWeapon.Types.Longsword);
                case 2:
                    return new RangedWeapon(RangedWeapon.Types.Rifle);
                case 3:
                    return new RangedWeapon(RangedWeapon.Types.Longbow);
                default:
                    return null;
            }
        }

        public bool CanBuy(int num)
        {
            return buyer.GoldPurse >= weapons[num].Cost;
        }

        public void Buy(int num)
        {
            buyer.GoldPurse -= weapons[num].Cost;
            buyer.Pickup(weapons[num]);
            weapons[num] = RandomWeapon();
        }

        public string DisplayWeapon(int num)
        {
            return $"Buy {weapons[num].WeaponType} ({weapons[num].Cost} Gold)";
        }
    }
}
