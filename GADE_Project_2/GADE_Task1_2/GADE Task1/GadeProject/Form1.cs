namespace GadeProject
{
    public partial class Form1 : Form
    {
        GameEngine Engine = new GameEngine();
        public Form1()
        {
            InitializeComponent();

            gMap.Text = Engine.MAP.FillMap();
            textBox1.Text = Engine.MAP.Player.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
            
        }
        public void updateform()
        {
            gMap.Text = Engine.MAP.ToString();
            

        }
        //assigning actions to the buttons for movement 
        private void BtnUp_Click(object sender, EventArgs e)
        {
            Engine.MovePlayer(Character.MovementEnum.Up);
            textBox1.Text = Engine.MAP.Player.ToString();
            gMap.Text = Engine.MAP.FillMap();
            Engine.MoveEnemies(Character.MovementEnum.Up);
            for (int i = 0; i < Engine.MAP.Enemies.Length; i++)
            {
                txtEnemy.Text = Engine.MAP.Enemies[i].ToString();
            }
        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            Engine.MovePlayer(Character.MovementEnum.Right);
            textBox1.Text = Engine.MAP.Player.ToString();
            gMap.Text = Engine.MAP.FillMap();
            Engine.MoveEnemies(Character.MovementEnum.Right);
            for (int i = 0; i < Engine.MAP.Enemies.Length; i++)
            {
                txtEnemy.Text = Engine.MAP.Enemies[i].ToString();
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            Engine.MovePlayer(Character.MovementEnum.Down);
            textBox1.Text = Engine.MAP.Player.ToString();
            gMap.Text = Engine.MAP.FillMap();
            Engine.MoveEnemies(Character.MovementEnum.Down);
            for (int i = 0; i < Engine.MAP.Enemies.Length; i++)
            {
                txtEnemy.Text = Engine.MAP.Enemies[i].ToString();
            }
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            Engine.MovePlayer(Character.MovementEnum.Left);
            textBox1.Text = Engine.MAP.Player.ToString();
            gMap.Text = Engine.MAP.FillMap();
            Engine.MoveEnemies(Character.MovementEnum.Left);
            for (int i = 0; i < Engine.MAP.Enemies.Length; i++)
            {
                txtEnemy.Text = Engine.MAP.Enemies[i].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Engine.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Engine.Load();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            Engine.PlayerAttack();
            textBox1.Text = Engine.MAP.Player.ToString();
            for (int i = 0; i < Engine.MAP.Enemies.Length; i++)
            {
                txtEnemy.Text = Engine.MAP.Enemies[i].ToString();
            }
        }
    }
}