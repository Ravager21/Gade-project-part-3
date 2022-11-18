using System.Reflection.Metadata;

namespace GadeProject
{
    public partial class Form1 : Form
    {
        GameEngine engine = new GameEngine();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateShop();

            TextUpdates();
            for (int i = 0; i < engine.MAP.Enemies.Length; i++)
            {
                enemiesList.Items.Add(engine.MAP.Enemies[i].ToString()); ;
            }

        }

        #region Shop Methods

        private void UpdateShop()
        {
            shopDisplayTextBox.Text = "";
            shopItemList.Items.Clear();
            for (int i = 0; i < 3; i++)
            {
                shopDisplayTextBox.Text += "• " + engine.Shop.DisplayWeapon(i);
                shopDisplayTextBox.Text += Environment.NewLine;

                shopItemList.Items.Add(engine.Shop.DisplayWeapon(i));
            }
        }

        private void shopItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (engine.Shop.CanBuy(shopItemList.SelectedIndex))
            {
                BtnBuy.Enabled = true;
            }
            else
            {
                BtnBuy.Enabled = false;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEnemy.Text = enemiesList.Items[enemiesList.SelectedIndex].ToString();
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            if (shopItemList.SelectedIndex == -1) return;
            engine.Shop.Buy(shopItemList.SelectedIndex);
            TextUpdates();
            UpdateShop();
        }
        #endregion

        private void Direction(Character.MovementEnum movement)
        {
            //The player should move, then the enemies, then the enemies should attack, and then the information should be displayed
            engine.MovePlayer(movement);
            engine.MAP.UpdateVision();
            engine.MoveEnemies();
            engine.MAP.UpdateVision();
            engine.EnemiesAttack();

            TextUpdates();
        }

        private void TextUpdates()
        {
            playerStatsTxt.Text = engine.MAP.Player.ToString();
            engine.MAP.UpdateVision();
            gMap.Text = engine.ToString();

            for (int i = 0; i < enemiesList.Items.Count; i++)
            {
                if (engine.MAP.Enemies[i].IsDead())
                {
                    enemiesList.Items[i] = "This enemy is already dead";
                }
                else
                {
                    enemiesList.Items[i] = engine.MAP.Enemies[i].ToString();
                }
            }
        }

        #region DirectionalButtons

        private void BtnUp_Click(object sender, EventArgs e)
        {
            Direction(Character.MovementEnum.Up);
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            Direction(Character.MovementEnum.Right);

        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            Direction(Character.MovementEnum.Down);

        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            Direction(Character.MovementEnum.Left);

        }

        private void BtnWait_Click(object sender, EventArgs e)
        {
            Direction(Character.MovementEnum.NoMovement);
        }
        #endregion

        private void btnAttack_Click(object sender, EventArgs e)
        {
            if (enemiesList.SelectedIndex == -1) return; //nothing selected
            if (engine.MAP.Enemies[enemiesList.SelectedIndex].IsDead()) return; //preventing attacking dead enemies

            bool canAttack = engine.MAP.Player.CheckRange(engine.MAP.Enemies[enemiesList.SelectedIndex]); //stores whether the player can reach the selected enemy
            engine.MAP.Player.Attack(engine.MAP.Enemies[enemiesList.SelectedIndex]); //atempts the attack


            if (canAttack) txtEnemy.Text = "Attack Successful";
            else txtEnemy.Text = "Attack Unsucessful";

            //removing the enemy if they're dead
            if (engine.MAP.Enemies[enemiesList.SelectedIndex].IsDead())
            {
                engine.MAP.Player.Loot(engine.MAP.Enemies[enemiesList.SelectedIndex]); //looting the enemy player just killed
                SetSelectedTileToEmpty(engine.MAP.Enemies[enemiesList.SelectedIndex].X, engine.MAP.Enemies[enemiesList.SelectedIndex].Y);
                enemiesList.Items[enemiesList.SelectedIndex] = "This enemy is already dead.";
                txtEnemy.Text = "The selected enemy is already dead";
            }
            else
            {
                enemiesList.Items[enemiesList.SelectedIndex] = engine.MAP.Enemies[enemiesList.SelectedIndex].ToString();
                txtEnemy.Text = enemiesList.Items[enemiesList.SelectedIndex].ToString(); //displaying information about the attack
            }

            TextUpdates();
            engine.EnemiesAttack(); //enemies attack after player does
        }

        //Takes in an x and y pos and sets that tile to empty, then updates the map
        private void SetSelectedTileToEmpty(int theX, int theY)
        {
            engine.MAP.Maps[theY, theX] = new EmptyTile(theX, theY);
            TextUpdates();
        }

        #region Save and Load
        private void btnSave_Click(object sender, EventArgs e)
        {
            engine.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            engine.Load();
            TextUpdates();
        }
        #endregion




    }
}