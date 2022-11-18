using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Map
    {
        protected Tile[,] mapContainer;
        protected Hero PLAYER;
        public Enemy[] Enemies;
        public int mapWidth;
        public int mapHeight;
        Random number = new Random();
        protected Item?[] items;
        public readonly string HERO = "H", SWAMPCTREATURE = "🤑", EMPTY = " . ", OBSTACLE = "X", MAGE = "M", GOLD ="G", DAGGER = "D", LONGSWORD = "↑", RIFLE = "├", LONGBOW = "◄", LEADER = "L";

        public Item?[] Items { get { return items; } set { items = value; } }
        public Tile[,] Maps { get { return mapContainer; } set { mapContainer = value; } }
        public Hero Player { get { return PLAYER; } set { PLAYER = value; } }

        //added Mage and Gold but have no value as of yet.
        //generating the map size 
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int NumOfEnemies, int GoldNum, int numOfWeapons)
        {
            items = new Item[GoldNum + numOfWeapons];
            mapWidth = number.Next(minWidth, maxWidth);

            mapHeight = number.Next(minHeight, maxHeight);
            mapContainer = new Tile[mapHeight, mapWidth];


            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if ((i == 0 || i == mapHeight - 1) || (j == 0 || j == mapWidth - 1))
                    {
                        mapContainer[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        mapContainer[i, j] = new EmptyTile(i, j);
                    }
                }
            }


            PLAYER = (Hero)Create(Tile.TileType.Hero);


            Enemies = new Enemy[NumOfEnemies];

            //filling the enemy array
            for (int i = 0; i < Enemies.Length - 1; i++)
            {
                Enemies[i] = (Enemy)Create(Tile.TileType.Enemy);
            }
            //leader
            AddLeader();

            //filling the items array
            for (int i = 0; i < GoldNum; i++)
            {
                _ = (Gold)Create(Tile.TileType.Gold);
            }
            for (int i = 0; i < numOfWeapons; i++)
            {
                _ = (Weapon)Create(Tile.TileType.Weapon);
            }


            UpdateVision();
        }

        private void AddLeader()
        {
            int yran, xran;
            bool loop;
            do
            {
                yran = number.Next(1, mapHeight - 1);
                xran = number.Next(1, mapWidth - 1);

                if (mapContainer[yran, xran] is EmptyTile)
                {
                    loop = false;
                }
                else
                {
                    loop = true;
                }
            } while (loop);

            Leader leader = new Leader(xran, yran) { Target = PLAYER};
            mapContainer[yran, xran] = leader;
            Enemies[Enemies.Length - 1] = leader;
            AddEnemyToArray(leader);
        }

        //creating different tile type objects, for respawning 
        private Tile Create(Tile.TileType Type)
        {
            int yran = 0, xran = 0;
            bool loop = true;
            while(loop)
            {
                yran = number.Next(1, mapHeight - 1);
                xran = number.Next(1, mapWidth - 1);  

                if (mapContainer[yran,xran] is EmptyTile)
                {
                    loop = false;
                }
                else
                {
                    loop = true;
                }
            }

            if (Type == Tile.TileType.Hero)
            {
                Hero hero = new Hero(xran, yran, 95, 95);
                mapContainer[hero.Y, hero.X] = hero;
                return hero;
            }
            else if (Type == Tile.TileType.Enemy)
            {
                Random choice = new Random();
                int CHOICE = choice.Next(2);

                if(CHOICE == 0)
                {
                    SwampCreatures newEnemy = new SwampCreatures(xran, yran);
                    mapContainer[yran, xran] = newEnemy;
                    AddEnemyToArray(newEnemy);
                    return newEnemy;
                }
                else
                {
                    Mage newEnemy = new Mage(xran, yran);
                    mapContainer[yran, xran] = newEnemy;
                    AddEnemyToArray(newEnemy);
                    return newEnemy;
                }
            }
            else if(Type == Tile.TileType.Gold)
            {
                Gold currency = new Gold(xran, yran);
                mapContainer[yran, xran] = currency;
                AddItemToArray(currency);
                return currency;
            }
            else if(Type == Tile.TileType.Weapon)
            {
                Random choice = new Random();
                int CHOICE = choice.Next(4);
                Weapon weapon;
                switch (CHOICE)
                {
                    case 0:
                        weapon = new MeleeWeapon(MeleeWeapon.Types.Dagger, xran, yran);
                        break;
                    case 1:
                        weapon = new MeleeWeapon(MeleeWeapon.Types.Longsword, xran, yran);
                        break;
                    case 2:
                        weapon = new RangedWeapon(RangedWeapon.Types.Rifle, xran, yran);
                        break;
                    case 3:
                        weapon = new RangedWeapon(RangedWeapon.Types.Longbow, xran, yran);
                        break;
                    default:
                        return new EmptyTile(xran, yran); //unreachable but here so no error from switch case
                }
                mapContainer[yran, xran] = weapon;
                AddItemToArray(weapon);
                return weapon;
            }

            //returning EmptyTile as a default case
            return new EmptyTile(xran, yran);
        }

        private void AddItemToArray(Item item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is null)
                {
                    items[i] = item;
                    break;
                }
            }
        }

        private void AddEnemyToArray(Enemy newEnemy)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Enemies[i] is null)
                {
                    Enemies[i] = newEnemy;
                    break;
                }
            }
        }
        //This method has been updated and improved as it didn't work for enemies
        public void UpdateVision()
        {
            PLAYER.Vision[0] = mapContainer[PLAYER.Y-1, PLAYER.X];//north
            PLAYER.Vision[1] = mapContainer[PLAYER.Y+1, PLAYER.X];//south
            PLAYER.Vision[2] = mapContainer[PLAYER.Y, PLAYER.X-1];//left
            PLAYER.Vision[3] = mapContainer[PLAYER.Y, PLAYER.X+1];//right

            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].Vision[0] = mapContainer[Enemies[i].Y - 1, Enemies[i].X];//north
                Enemies[i].Vision[1] = mapContainer[Enemies[i].Y + 1, Enemies[i].X];//south
                Enemies[i].Vision[2] = mapContainer[Enemies[i].Y, Enemies[i].X - 1];//left
                Enemies[i].Vision[3] = mapContainer[Enemies[i].Y, Enemies[i].X + 1];//right
            }
        }

        public Item? GetGetItemAtPosition(int y, int x)
        {
            for(int i = 0; i < items.Length; i++)
            {
                //despite the warning, these wont be reached if they're null since the null check above skips them.
                if (items[i] is not null && items[i].Y == y && items[i].X == x)
                {
                    Item? a = items[i];
                    items[i] = null;
                    return a;
                }
            }
            return null;
        }



    }
}
