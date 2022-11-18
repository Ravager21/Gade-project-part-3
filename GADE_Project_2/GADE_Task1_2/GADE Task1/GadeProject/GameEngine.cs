using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.ExceptionServices;


namespace GadeProject
{
    internal class GameEngine 
    {
        public Label maplabel = new Label();
        private Map map;

        public Map MAP
        {
            get { return map; }
            set { map = value; }
        }
        public GameEngine()
        {
            MAP = new Map(10, 20, 10, 20, 1, 2);
            
        }
        //a boolean to check whether character will be able to move
        public bool MovePlayer(Character.MovementEnum direction)
        {
           
            MAP.Player.Move(direction);
            //MAP.Maps[MAP.Player.Y, MAP.Player.X] = new Hero(MAP.Player.Y, MAP.Player.X, Tile.TileType.Hero);
            

            if (MAP.Player.ReturnMove(direction) == direction )
            {
                if(direction == Character.MovementEnum.Up && MAP.Player.Vision[0] is EmptyTile)
                {
                    MAP.Maps[MAP.Player.Y+1, MAP.Player.X] = new EmptyTile(MAP.Player.X, MAP.Player.Y, Tile.TileType.Empty);
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = MAP.Maps[MAP.Player.Y - 1, MAP.Player.X];
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = new Hero(MAP.Player.Y-1, MAP.Player.X, Tile.TileType.Hero);

                    if (MAP.Player.Vision[0] is Gold)
                    {
                        MAP.Player.Pickup(MAP.getGetItemAtPosition(MAP.Player.X, MAP.Player.Y));
                    }
                }

                if (direction == Character.MovementEnum.Down && MAP.Player.Vision[1] is EmptyTile)
                {
                    MAP.Maps[MAP.Player.Y -1, MAP.Player.X] = new EmptyTile(MAP.Player.X, MAP.Player.Y, Tile.TileType.Empty);
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = MAP.Maps[MAP.Player.Y + 1, MAP.Player.X];
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = new Hero(MAP.Player.Y+1, MAP.Player.X, Tile.TileType.Hero);
                    
                    if (MAP.Player.Vision[1] is Gold)
                    {
                        MAP.Player.Pickup(MAP.getGetItemAtPosition(MAP.Player.X, MAP.Player.Y));
                    }
                }

                if (direction == Character.MovementEnum.Right && MAP.Player.Vision[3] is EmptyTile)
                {

                    MAP.Maps[MAP.Player.Y, MAP.Player.X - 1] = new EmptyTile(MAP.Player.X, MAP.Player.Y, Tile.TileType.Empty);
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = MAP.Maps[MAP.Player.Y, MAP.Player.X + 1];
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = new Hero(MAP.Player.Y, MAP.Player.X+1, Tile.TileType.Hero);

                    if (MAP.Player.Vision[3] is Gold)
                    {
                        MAP.Player.Pickup(MAP.getGetItemAtPosition(MAP.Player.X, MAP.Player.Y));
                    }
                }

                if (direction == Character.MovementEnum.Left && MAP.Player.Vision[2] is EmptyTile)
                {
                    MAP.Maps[MAP.Player.Y, MAP.Player.X + 1] = new EmptyTile(MAP.Player.X, MAP.Player.Y, Tile.TileType.Empty);
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = MAP.Maps[MAP.Player.Y, MAP.Player.X - 1];
                    MAP.Maps[MAP.Player.Y, MAP.Player.X] = new Hero(MAP.Player.Y, MAP.Player.X-1, Tile.TileType.Hero);

                    if (MAP.Player.Vision[2] is Gold)
                    {
                        MAP.Player.Pickup(MAP.getGetItemAtPosition(MAP.Player.X, MAP.Player.Y));
                    }
                    
                }
                return true;
            }
            else
            {
                return false;
            }
           
           
        }
        
        //Part 2: Question 4
            public string fileSave = "savegame";
            private Map saveGame;
            public BinaryFormatter bin = new BinaryFormatter(); 

            public void Save()
            {
            FileStream file = new FileStream(fileSave, FileMode.Create);

            try
            {
                bin.Serialize(file, saveGame);
            }
            catch (FileNotFoundException e)
            {
                string s = "Serilization failed";
                MessageBox.Show(s);
                throw;
            }
            finally
            {
                file.Close();
            }

        }
        public void Load()
        {
            FileStream file = new FileStream(fileSave, FileMode.Open);

            try
            {
                 bin.Deserialize(file);
            }
            catch(FileNotFoundException e)
            {
                string s = "Deserialization failed";
                MessageBox.Show(s);
                throw;
            }
            finally
            {
                file.Close();
            }
        }

        public void MoveEnemies(Character.MovementEnum direction)
        {

            Random ran = new Random();
            int movement = ran.Next(0, 4);
            Character.MovementEnum eMove = (Character.MovementEnum)movement;

            for (int i = 0; i < MAP.Enemies.Length; i++)
            {
                MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X, Tile.TileType.Enemy);
                MAP.Enemies[i].Move(eMove);
                if (direction == Character.MovementEnum.Up && MAP.Enemies[i].Vision[0] is EmptyTile)
                {
                    if (eMove == Character.MovementEnum.Up)
                    {
                        MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y - 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Down)
                    {
                        MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y + 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Right)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X + 1, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Left)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X - 1, Tile.TileType.Enemy);
                    }
                }
                else if (direction == Character.MovementEnum.Down && MAP.Enemies[i].Vision[1] is EmptyTile)
                {
                    if (eMove == Character.MovementEnum.Up)
                    {
                        MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y - 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Down)
                    {
                        MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y + 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Right)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X + 1, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Left)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X - 1, Tile.TileType.Enemy);
                    }
                }
                else if (direction == Character.MovementEnum.Right && MAP.Enemies[i].Vision[3] is EmptyTile)
                {
                    if (eMove == Character.MovementEnum.Up)
                    {
                        MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y - 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Down)
                    {
                        MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y + 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Right)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X + 1, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Left)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X - 1, Tile.TileType.Enemy);
                    }
                }
                else if (direction == Character.MovementEnum.Left && MAP.Enemies[i].Vision[2] is EmptyTile)
                {
                    if (eMove == Character.MovementEnum.Up)
                    {
                        MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y - 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Down)
                    {
                        MAP.Maps[MAP.Enemies[i].Y - 1, MAP.Enemies[i].X] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y + 1, MAP.Enemies[i].X];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y + 1, MAP.Enemies[i].X, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Right)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X + 1, Tile.TileType.Enemy);
                    }
                    else if (eMove == Character.MovementEnum.Left)
                    {
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X + 1] = new EmptyTile(MAP.Enemies[i].X, MAP.Enemies[i].Y, Tile.TileType.Empty);
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X - 1];
                        MAP.Maps[MAP.Enemies[i].Y, MAP.Enemies[i].X] = new SwampCreatures(MAP.Enemies[i].Y, MAP.Enemies[i].X - 1, Tile.TileType.Enemy);
                    }
                }
            }

        }
        public void PlayerAttack()
        {
            for (int i = 0; i < MAP.Enemies.Length; i++)
            {
                if(MAP.Enemies[i] == null)
                {
                    continue;
                }
                bool r = MAP.Player.CheckRange(MAP.Enemies[i]);
                if(r == true)
                {
                    MAP.Player.Attack(MAP.Enemies[i]);
                }
                else if(r == false)
                {
                    MAP.Player.Attack(MAP.Enemies[i]);
                }
            }
        }

        public void EnemyAttacks()
        {
            for (int i = 0; i < MAP.Enemies.Length; i++)
            {
                if (MAP.Enemies[i] == null)
                {
                    continue;
                }
                bool r = MAP.Player.CheckRange(MAP.Enemies[i]);
                if (r == true)
                {
                    MAP.Player.Attack(MAP.Enemies[i]);
                }
                else if (r == false)
                {
                    MAP.Player.Attack(MAP.Enemies[i]);
                }
            }

        }

    }
}
