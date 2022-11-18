using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class Map
    {
        public Enemy[] Enemies;
        protected SwampCreatures enemyMove;
        protected Hero PLAYER;
        protected Tile[,] mapContainer;
        protected Item[] items;
        public Item[] Items { get { return items; } set { items = value; } }
        public Tile[,] Maps { get { return mapContainer; } set { mapContainer = value; } }
        public int mapWidth;
        public int mapHeight;

        Random number = new Random();
        public Hero Player { get { return PLAYER; } set { PLAYER = value; } }
        public SwampCreatures EnemyMove { get { return enemyMove; } set { enemyMove = value; } }

        //added Mage and Gold but have no value as of yet.
        readonly string Hero = "H", SwampC = "SC", Empty = " . ", Obstacle = "X", MageE = "M", gold ="G";
        //generating the map size 
        public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int NumOfEnemies, int GoldNum)
        {
            items = new Item[GoldNum];
            mapWidth = number.Next(minWidth, maxWidth);

            mapHeight = number.Next(minHeight, maxHeight);
            mapContainer = new Tile[mapHeight, mapWidth];
            for (int i = 0; i < mapHeight; i++)
            {
                for(int j = 0; j < mapWidth; j++)
                {
                    if((i == 0 || i == mapHeight - 1) || (j == 0 || j == mapWidth - 1))
                    {
                        mapContainer[i,j] = new Obstacle(i,j,Tile.TileType.Obstacle);
                    }
                    else
                    {
                        mapContainer[i, j] = new EmptyTile(i,j,Tile.TileType.Empty);
                    }
                }
            }

            
            

            Enemies = new Enemy[NumOfEnemies];

            PLAYER = (Hero)Create(Tile.TileType.Hero);

            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i] = (Enemy)Create(Tile.TileType.Enemy);
            }

            for(int i = 0; i < Items.Length; i++)
            {
                items[i] = (Item) Create(Tile.TileType.Gold);
            }
            UpdateVision(Player);
            for (int i = 0; i < Enemies.Length; i++)
            {
                UpdateVision(Enemies[i]);
            }
        }
        //creating different tile type objects, for respawning 
        private Tile Create(Tile.TileType Type)
        {
            int yran = 0, xran = 0;
            bool loop = true;
            while(loop )
            {
                yran = number.Next(1,mapHeight -1);
                xran = number.Next(1,mapWidth -1);  

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
                Hero hero = new Hero(xran, yran,Tile.TileType.Hero);
                mapContainer[hero.Y, hero.X] = hero;
                return hero;
            }
            else if (Type == Tile.TileType.Enemy)
            {
                Random choice = new Random();

                int CHOICE = choice.Next(2);

                if(CHOICE == 0)
                { 
                SwampCreatures newEnemy = new SwampCreatures(xran, yran, Tile.TileType.Enemy);
                mapContainer[yran, xran] = newEnemy;
                return newEnemy;
                }

                else
                {
                    Mage newEnemy = new Mage(xran, yran, 5, Tile.TileType.Enemy, 5, 5, "M");
                    mapContainer[yran, xran] = newEnemy;
                    return newEnemy;
                }
            }
            else if(Type == Tile.TileType.Gold)
            {
                Gold currency = new Gold(xran, yran, Tile.TileType.Gold);
                mapContainer[yran, xran] = currency;
                return currency;
            }
            return null;

        }
        public void UpdateVision(Character target)
        {
            target.Vision[0] = mapContainer[target.Y-1, target.X];//north
            target.Vision[1] = mapContainer[target.Y+1, target.X];//south
            target.Vision[2] = mapContainer[target.Y, target.X-1];//left
            target.Vision[3] = mapContainer[target.Y, target.X+1];//right
        }

        public string FillMap()
        {
            string map = "";
            for(int i = 0; i < mapHeight; i++)
            {
                for(int j = 0; j < mapWidth; j++)
                {
                    if(mapContainer[i, j] is Obstacle)
                    {
                        map += Obstacle; 
                    }
                    if (mapContainer[i, j] is EmptyTile)
                    {
                        map += Empty;
                    }
                    if (mapContainer[i, j] is Hero)
                    {
                        map += Hero;
                    }
                    if (mapContainer[i, j] is SwampCreatures)
                    {
                        map += SwampC;
                    }
                    if(mapContainer[i,j] is Gold)
                    {
                        map += gold;
                    }
                    if (mapContainer[i,j] is Mage)
                    {
                        map += MageE;
                    }
                    map += "";
                }
                map += Environment.NewLine; 
            }
            return map;
        }

        public Item getGetItemAtPosition(int x, int y)
        {

            for(var i = 0; i < items.Length; i++)
            {
                if (items[i].Y == y && items[i].X == x)
                {
                    Item a = items[i];
                    items[i] = null;

                    return a;
                }
            }
            return null;
        }



    }
}
