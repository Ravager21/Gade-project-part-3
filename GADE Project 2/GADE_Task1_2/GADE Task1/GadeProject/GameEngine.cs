using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadeProject
{
    internal class GameEngine 
    {
        private Map map;
        private Shop shop;
        public Map MAP { get { return map; } set { map = value; } }
        public Shop Shop { get { return shop; } }

        public GameEngine()
        {
            map = new Map(25, 30, 25, 30, 5, 4, 2);
            shop = new Shop(map.Player);
        }
        //a boolean to check whether character will be able to move
        //Note: an improved version from part 1 & 2
        public bool MovePlayer(Character.MovementEnum direction)
        {
            if (MAP.Player.ReturnMove(direction) == direction ) //move is valid
            {
                //checking for item infront of player
                switch (direction)
                {
                    case Character.MovementEnum.Up:
                        Item? item = map.GetGetItemAtPosition(map.Player.Y - 1, map.Player.X);
                        if (item is not null)
                        {
                            map.Player.Pickup(item);
                        }
                        break;
                    case Character.MovementEnum.Down:
                        Item? item2 = map.GetGetItemAtPosition(map.Player.Y + 1, map.Player.X);
                        if (item2 is not null)
                        {
                            map.Player.Pickup(item2);
                        }
                        break;
                    case Character.MovementEnum.Left:
                        Item? item3 = map.GetGetItemAtPosition(map.Player.Y, map.Player.X - 1);
                        if (item3 is not null)
                        {
                            map.Player.Pickup(item3);
                        }
                        break;
                    case Character.MovementEnum.Right:
                        Item? item4 = map.GetGetItemAtPosition(map.Player.Y, map.Player.X + 1);
                        if (item4 is not null)
                        {
                            map.Player.Pickup(item4);
                        }
                        break;
                }

                //player gets moved
                //Note: an improved version from part 1 & 2
                map.Player.Move(direction);
                map.Maps[map.Player.Y, map.Player.X] = map.Player;

                switch (direction)
                {
                    //Sets the tile the player was on to blank
                    case Character.MovementEnum.Up:
                        map.Maps[map.Player.Y + 1, map.Player.X] = new EmptyTile(map.Player.X, map.Player.Y);
                        break;
                    case Character.MovementEnum.Down:
                        map.Maps[map.Player.Y - 1, map.Player.X] = new EmptyTile(map.Player.X, map.Player.Y);
                        break;
                    case Character.MovementEnum.Left:
                        map.Maps[map.Player.Y, map.Player.X + 1] = new EmptyTile(map.Player.X, map.Player.Y);
                        break;
                    case Character.MovementEnum.Right:
                        map.Maps[map.Player.Y, map.Player.X - 1] = new EmptyTile(map.Player.X, map.Player.Y);
                        break;
                }
                map.UpdateVision();
                return true;
            }
            else
            {
                return false;
            }
           
           
        }
        //A method for enemy movement 
        //Note: an improved version from part 1 & 2
        public void MoveEnemies(Character.MovementEnum direction = Character.MovementEnum.NoMovement)
        {
            for (int i = 0; i < map.Enemies.Length; i++)
            {
                if (map.Enemies[i].IsDead()) continue; //prevents dead enemies from moving

                Character.MovementEnum movementDirection = map.Enemies[i].ReturnMove(direction); //storing the direction the enemy will move

                switch (movementDirection)
                {
                    case Character.MovementEnum.Up:
                        Item? item = map.GetGetItemAtPosition(map.Enemies[i].Y - 1, map.Enemies[i].X);
                        if (item is not null)
                        {
                            map.Enemies[i].Pickup(item);
                        }
                        break;
                    case Character.MovementEnum.Down:
                        Item? item2 = map.GetGetItemAtPosition(map.Enemies[i].Y + 1, map.Enemies[i].X);
                        if (item2 is not null)
                        {
                            map.Enemies[i].Pickup(item2);
                        }
                        break;
                    case Character.MovementEnum.Left:
                        Item? item3 = map.GetGetItemAtPosition(map.Enemies[i].Y - 1, map.Enemies[i].X);
                        if (item3 is not null)
                        {
                            map.Enemies[i].Pickup(item3);
                        }
                        break;
                    case Character.MovementEnum.Right:
                        Item? item4 = map.GetGetItemAtPosition(map.Enemies[i].Y - 1, map.Enemies[i].X);
                        if (item4 is not null)
                        {
                            map.Enemies[i].Pickup(item4);
                        }
                        break;
                    default: 
                        break;
                }
                map.Enemies[i].Move(movementDirection);
                map.Maps[map.Enemies[i].Y, map.Enemies[i].X] = map.Enemies[i];

                switch (movementDirection)
                {
                    //Sets the tile the Enemy was on to blank
                    case Character.MovementEnum.Up:
                        map.Maps[map.Enemies[i].Y + 1, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y);
                        break;
                    case Character.MovementEnum.Down:
                        map.Maps[map.Enemies[i].Y - 1, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y);
                        break;
                    case Character.MovementEnum.Left:
                        map.Maps[map.Enemies[i].Y, map.Enemies[i].X + 1] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y);
                        break;
                    case Character.MovementEnum.Right:
                        map.Maps[map.Enemies[i].Y, map.Enemies[i].X - 1] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y);
                        break;
                    default:
                        break;
                }
            }

            
        }
        
        //Note: an improved version from part 1 & 2
        public void EnemiesAttack()
        {
            for (int i = 0; i < map.Enemies.Length; i++)
            {
                if (map.Enemies[i].IsDead()) continue;

                switch (map.Enemies[i])
                {
                    default:
                        //Swamp Creature and Leader
                        map.Enemies[i].Attack(map.Player);
                        break;
                    case Mage:
                        map.Enemies[i].Attack(map.Player);
                        for (int j = 0; j < map.Enemies.Length; j++)
                        {
                            if (ReferenceEquals(map.Enemies[j], map.Enemies[i])) continue;
                            map.Enemies[i].Attack(map.Enemies[j]);

                            //sets the dead enemy to a blank tile.
                            if (map.Enemies[j].IsDead())
                            {
                                //prevents the player tile from being overwritten by blank tiles when moving into the space of dead enemy
                                if (!(map.Player.X == map.Enemies[j].X || map.Player.Y == map.Enemies[j].Y)) map.Maps[map.Enemies[j].Y, map.Enemies[j].X] = new EmptyTile(map.Enemies[j].X, map.Enemies[j].Y);
                                //checks that the mage is looting the correct enemy, they do not pick up the weapon though.
                                if (map.Enemies[i].CheckRange(map.Enemies[j])) map.Enemies[i].Loot(map.Enemies[j]);
                            }
                        }
                        break;
                }
                //sets the enemies tile to blank id they're dead
                if (map.Enemies[i].IsDead())
                {
                    map.Maps[map.Enemies[i].Y, map.Enemies[i].X] = new EmptyTile(map.Enemies[i].X, map.Enemies[i].Y);
                }
            }
        }

        public override string ToString()
        {
            string mapOutput = "";
            for (int i = 0; i < map.mapHeight; i++)
            {
                for (int j = 0; j < map.mapWidth; j++)
                {
                    switch (map.Maps[i, j])
                    {
                        case Hero:
                            mapOutput += map.HERO;
                            break;
                        case SwampCreatures:
                            mapOutput += map.SWAMPCTREATURE;
                            break;
                        case Mage:
                            mapOutput += map.MAGE;
                            break;
                        case Gold:
                            mapOutput += map.GOLD;
                            break;
                        case Obstacle:
                            mapOutput += map.OBSTACLE;
                            break;
                        case EmptyTile:
                            mapOutput += map.EMPTY;
                            break;
                        case MeleeWeapon:
                            if (((MeleeWeapon)map.Maps[i, j]).WeaponType == "Dagger") mapOutput += map.DAGGER;
                            else mapOutput += map.LONGSWORD;
                            break;
                        case RangedWeapon:
                            if (((RangedWeapon)map.Maps[i, j]).WeaponType == "Rifle") mapOutput += map.RIFLE;
                            else mapOutput += map.LONGBOW;
                            break;
                        case Leader:
                            mapOutput += map.LEADER;
                            break;
                        default:
                            //here to show if any unexpected objects make it into the game.
                            mapOutput += "♦";
                            break;
                    }
                }
                mapOutput += Environment.NewLine;
            }
            return mapOutput;
        }

        public void Save()
        {
            //saving all the data into XML tables
            DataSet dataSet = new DataSet();
            DataTable mapCreationTable = new DataTable();
            DataTable charactersTable = new DataTable();
            DataTable goldTable = new DataTable();
            DataTable weaponsTable = new DataTable();

            //map creation table
            dataSet.Tables.Add(mapCreationTable);
            mapCreationTable.Columns.Add(new DataColumn("Width", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("Height", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("EnemyCount", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("GoldCount", typeof(int)));
            mapCreationTable.Columns.Add(new DataColumn("WeaponCount", typeof(int)));

            //characters table
            dataSet.Tables.Add(charactersTable);
            charactersTable.Columns.Add(new DataColumn("CharacterType", typeof(string)));
            charactersTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("HP", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("GoldPurse", typeof(int)));
            charactersTable.Columns.Add(new DataColumn("Weapon", typeof(string)));
            charactersTable.Columns.Add(new DataColumn("Dead", typeof(bool)));


            //gold table
            dataSet.Tables.Add(goldTable);
            goldTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            goldTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            goldTable.Columns.Add(new DataColumn("GoldCount", typeof(int)));

            //weapons table for in map weapons
            dataSet.Tables.Add(weaponsTable);
            weaponsTable.Columns.Add(new DataColumn("Type", typeof(string)));
            weaponsTable.Columns.Add(new DataColumn("Xposition", typeof(int)));
            weaponsTable.Columns.Add(new DataColumn("Yposition", typeof(int)));
            weaponsTable.Columns.Add(new DataColumn("durability", typeof(int)));


            //writing data into tables
            //map creation table
            mapCreationTable.Rows.Add(MAP.mapWidth, MAP.mapHeight, MAP.Enemies.Length, 4, 2);

            //characters table
            if (MAP.Player.WeaponEquiped is not null) charactersTable.Rows.Add("Hero", MAP.Player.X, MAP.Player.Y, MAP.Player.HP, MAP.Player.GoldPurse, MAP.Player.WeaponEquiped.WeaponType, MAP.Player.IsDead());
            else charactersTable.Rows.Add("Hero", MAP.Player.X, MAP.Player.Y, MAP.Player.HP, MAP.Player.GoldPurse, "BareHands", MAP.Player.IsDead());

            for (int i = 0; i < MAP.Enemies.Length; i++)
            {
                switch (MAP.Enemies[i])
                {
                    case SwampCreatures:
                        charactersTable.Rows.Add("SwampCreature", MAP.Enemies[i].X, MAP.Enemies[i].Y, MAP.Enemies[i].HP, MAP.Enemies[i].GoldPurse, MAP.Enemies[i].WeaponEquiped.WeaponType, MAP.Enemies[i].IsDead());
                        break;
                    case Mage:
                        charactersTable.Rows.Add("Mage", MAP.Enemies[i].X, MAP.Enemies[i].Y, MAP.Enemies[i].HP, MAP.Enemies[i].GoldPurse, "BareHands", MAP.Enemies[i].IsDead());
                        break;
                    case Leader:
                        charactersTable.Rows.Add("Leader", MAP.Enemies[i].X, MAP.Enemies[i].Y, MAP.Enemies[i].HP, MAP.Enemies[i].GoldPurse, MAP.Enemies[i].WeaponEquiped.WeaponType, MAP.Enemies[i].IsDead());
                        break;
                    default:
                        break;
                }
            }

            //gold and weapons table
            for (int i = 0; i < MAP.Items.Length; i++)
            {
                switch (MAP.Items[i])
                {
                    case Gold gold:
                        goldTable.Rows.Add(gold.X, gold.Y, gold.GoldDropAmount);
                        break;
                    case MeleeWeapon melee:
                        weaponsTable.Rows.Add(melee.WeaponType, melee.X, melee.Y, melee.Durability);
                        break;
                    case RangedWeapon ranged:
                        weaponsTable.Rows.Add(ranged.WeaponType, ranged.X, ranged.Y, ranged.Durability);
                        break;
                }
            }

            dataSet.WriteXml("Tables.xml");
        }
        public void Load()
        { 
            DataSet loadingData = new DataSet();
            loadingData.ReadXml("Tables.xml");

            //Map Creation
            int width_MC, height_MC, enemies_MC, gold_MC, weapons_MC;
            width_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["Width"]);
            height_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["Height"]);
            enemies_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["EnemyCount"]);
            gold_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["GoldCount"]);
            weapons_MC = Convert.ToInt32(loadingData.Tables[0].Rows[0]["WeaponCount"]);

            map = new Map(width_MC, width_MC, height_MC, height_MC, enemies_MC, gold_MC, weapons_MC);

            //emptying the map of its auto-generated content
            for (int i = 1; i < height_MC - 1; i++)
            {
                for (int j = 1; j < width_MC - 1; j++)
                {
                    map.Maps[i, j] = new EmptyTile(j, i);
                }
            }
            map.Enemies = new Enemy[enemies_MC];
            map.Items = new Item[gold_MC + weapons_MC];

            //Characters
            foreach (DataRow row in loadingData.Tables[1].Rows) //Characters Table
            {
                string type_CH;
                int x_CH, y_CH, hp_CH, goldPurse_CH;
                string weapon_CH;
                bool dead_CH;
                
                type_CH = (string)row["CharacterType"];
                x_CH = Convert.ToInt32(row["Xposition"]);
                y_CH = Convert.ToInt32(row["Yposition"]);
                hp_CH = Convert.ToInt32(row["HP"]);
                goldPurse_CH = Convert.ToInt32(row["GoldPurse"]);
                weapon_CH = (string)row["Weapon"];
                dead_CH = Convert.ToBoolean(row["Dead"]);
                Weapon? w = weapon_CH switch
                {
                    "Rifle" => new RangedWeapon(RangedWeapon.Types.Rifle),
                    "Longbow" => new RangedWeapon(RangedWeapon.Types.Longbow),
                    "Dagger" => new MeleeWeapon(MeleeWeapon.Types.Dagger),
                    "Longsword" => new MeleeWeapon(MeleeWeapon.Types.Longsword),
                    _ => null
                };

                switch (type_CH)
                {
                    case "Hero":
                        Hero hero = new Hero(x_CH, y_CH, hp_CH, hp_CH) { GoldPurse = goldPurse_CH };
                        if (w is not null) hero.Pickup(w);
                        map.Player = hero;
                        map.Maps[y_CH, x_CH] = hero;
                        break;
                    case "SwampCreature":
                        SwampCreatures swampCreatures = new SwampCreatures(x_CH, y_CH, hp_CH) { GoldPurse = goldPurse_CH};
                        if (w is not null) swampCreatures.Pickup(w);
                        for (int i = 0; i < map.Enemies.Length; i++)
                        {
                            if (map.Enemies[i] is null)
                            {
                                map.Enemies[i] = swampCreatures;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            map.Maps[y_CH, x_CH] = swampCreatures;
                        }
                        break;
                    case "Mage":
                        Mage mage = new Mage(x_CH, y_CH, hp_CH) { GoldPurse = goldPurse_CH };
                        if (w is not null) mage.Pickup(w);
                        for (int i = 0; i < map.Enemies.Length; i++)
                        {
                            if (map.Enemies[i] is null)
                            {
                                map.Enemies[i] = mage;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            map.Maps[y_CH, x_CH] = mage;
                        }
                        break;
                    case "Leader":
                        Leader leader = new Leader(x_CH, y_CH, hp_CH) { GoldPurse = goldPurse_CH, Target = map.Player };
                        if (w is not null) leader.Pickup(w);
                        for (int i = 0; i < map.Enemies.Length; i++)
                        {
                            if (map.Enemies[i] is null)
                            {
                                map.Enemies[i] = leader;
                                break;
                            }
                        }
                        if (!dead_CH)
                        {
                            map.Maps[y_CH, x_CH] = leader;
                        }
                        break;

                }
            }

            //gold
            foreach (DataRow row in loadingData.Tables[2].Rows) //gold table
            {
                int x_GO, y_GO, gold_GO;

                x_GO = Convert.ToInt32(row["Xposition"]);
                y_GO = Convert.ToInt32(row["Yposition"]);
                gold_GO = Convert.ToInt32(row["GoldCount"]);

                
                Gold gold = new Gold(x_GO, y_GO) { GoldDropAmount = gold_GO };
                for (int i = 0; i < map.Items.Length; i++)
                {
                    if (map.Items[i] is null)
                    {
                        map.Items[i] = gold;
                        break;
                    }
                }
                map.Maps[y_GO, x_GO] = gold;
            }

            //weapons on map
            foreach (DataRow row in loadingData.Tables[3].Rows) //weapons table
            {
                string type;
                int x_W, y_W, durability_W;

                type = (string)row["Type"];
                x_W = Convert.ToInt32(row["Xposition"]);
                y_W = Convert.ToInt32(row["Yposition"]);
                durability_W = Convert.ToInt32(row["durability"]);

                if (x_W == 0 || y_W == 0)
                {
                    continue;
                }
                switch (type)
                {
                    case "Rifle":
                        RangedWeapon rifle = new RangedWeapon(RangedWeapon.Types.Rifle, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = rifle;
                                break;
                            }
                        }
                        map.Maps[y_W, x_W] = rifle;
                        break;
                    case "LongBow":
                        RangedWeapon longbow = new RangedWeapon(RangedWeapon.Types.Longbow, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = longbow;
                                break;
                            }
                        }
                        map.Maps[y_W, x_W] = longbow;
                        break;
                    case "Dagger":
                        MeleeWeapon dagger = new MeleeWeapon(MeleeWeapon.Types.Dagger, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = dagger;
                                break;
                            }
                        }
                        map.Maps[y_W, x_W] = dagger;
                        break;
                    case "Longsword":
                        MeleeWeapon longsword = new MeleeWeapon(MeleeWeapon.Types.Longsword, x_W, y_W) { Durability = durability_W };
                        for (int i = 0; i < map.Items.Length; i++)
                        {
                            if (map.Items[i] is null)
                            {
                                map.Items[i] = longsword;
                                break;
                            }
                        }
                        map.Maps[y_W, x_W] = longsword;
                        break;
                }
            }
            map.UpdateVision();
        }
    }
}
