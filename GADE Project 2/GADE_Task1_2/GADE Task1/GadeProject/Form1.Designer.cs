namespace GadeProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.BtnRight = new System.Windows.Forms.Button();
            this.BtnDown = new System.Windows.Forms.Button();
            this.gMap = new System.Windows.Forms.Label();
            this.BtnAttack = new System.Windows.Forms.Button();
            this.playerStatsTxt = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.txtEnemy = new System.Windows.Forms.TextBox();
            this.BtnWait = new System.Windows.Forms.Button();
            this.enemiesList = new System.Windows.Forms.ComboBox();
            this.BtnBuy = new System.Windows.Forms.Button();
            this.shopItemList = new System.Windows.Forms.ComboBox();
            this.shopDisplayTextBox = new System.Windows.Forms.TextBox();
            this.shopLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(724, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnUp
            // 
            this.BtnUp.Location = new System.Drawing.Point(725, 371);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(115, 62);
            this.BtnUp.TabIndex = 0;
            this.BtnUp.Text = "Up";
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnLeft
            // 
            this.BtnLeft.Location = new System.Drawing.Point(604, 439);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(115, 62);
            this.BtnLeft.TabIndex = 1;
            this.BtnLeft.Text = "Left";
            this.BtnLeft.UseVisualStyleBackColor = true;
            this.BtnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // BtnRight
            // 
            this.BtnRight.Location = new System.Drawing.Point(846, 439);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(115, 62);
            this.BtnRight.TabIndex = 2;
            this.BtnRight.Text = "Right";
            this.BtnRight.UseVisualStyleBackColor = true;
            this.BtnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Location = new System.Drawing.Point(725, 507);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(115, 62);
            this.BtnDown.TabIndex = 3;
            this.BtnDown.Text = "Down";
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // gMap
            // 
            this.gMap.BackColor = System.Drawing.Color.White;
            this.gMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMap.ForeColor = System.Drawing.Color.Black;
            this.gMap.Location = new System.Drawing.Point(12, 9);
            this.gMap.Name = "gMap";
            this.gMap.Size = new System.Drawing.Size(558, 683);
            this.gMap.TabIndex = 6;
            this.gMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnAttack
            // 
            this.BtnAttack.Location = new System.Drawing.Point(587, 291);
            this.BtnAttack.Name = "BtnAttack";
            this.BtnAttack.Size = new System.Drawing.Size(524, 62);
            this.BtnAttack.TabIndex = 7;
            this.BtnAttack.Text = "Attack";
            this.BtnAttack.UseVisualStyleBackColor = true;
            this.BtnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // playerStatsTxt
            // 
            this.playerStatsTxt.Location = new System.Drawing.Point(587, 9);
            this.playerStatsTxt.Multiline = true;
            this.playerStatsTxt.Name = "playerStatsTxt";
            this.playerStatsTxt.Size = new System.Drawing.Size(236, 170);
            this.playerStatsTxt.TabIndex = 8;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(996, 371);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(115, 97);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "Save Game";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(996, 474);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(115, 95);
            this.BtnLoad.TabIndex = 9;
            this.BtnLoad.Text = "Load Game";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtEnemy
            // 
            this.txtEnemy.Location = new System.Drawing.Point(587, 185);
            this.txtEnemy.Multiline = true;
            this.txtEnemy.Name = "txtEnemy";
            this.txtEnemy.Size = new System.Drawing.Size(524, 71);
            this.txtEnemy.TabIndex = 10;
            // 
            // BtnWait
            // 
            this.BtnWait.Location = new System.Drawing.Point(725, 439);
            this.BtnWait.Name = "BtnWait";
            this.BtnWait.Size = new System.Drawing.Size(115, 62);
            this.BtnWait.TabIndex = 11;
            this.BtnWait.Text = "Wait";
            this.BtnWait.UseVisualStyleBackColor = true;
            this.BtnWait.Click += new System.EventHandler(this.BtnWait_Click);
            // 
            // enemiesList
            // 
            this.enemiesList.FormattingEnabled = true;
            this.enemiesList.Location = new System.Drawing.Point(587, 262);
            this.enemiesList.Name = "enemiesList";
            this.enemiesList.Size = new System.Drawing.Size(524, 23);
            this.enemiesList.TabIndex = 12;
            this.enemiesList.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnBuy
            // 
            this.BtnBuy.Location = new System.Drawing.Point(1015, 155);
            this.BtnBuy.Name = "BtnBuy";
            this.BtnBuy.Size = new System.Drawing.Size(96, 23);
            this.BtnBuy.TabIndex = 13;
            this.BtnBuy.Text = "Buy";
            this.BtnBuy.UseVisualStyleBackColor = true;
            this.BtnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // shopItemList
            // 
            this.shopItemList.FormattingEnabled = true;
            this.shopItemList.Location = new System.Drawing.Point(829, 156);
            this.shopItemList.Name = "shopItemList";
            this.shopItemList.Size = new System.Drawing.Size(180, 23);
            this.shopItemList.TabIndex = 14;
            this.shopItemList.SelectedIndexChanged += new System.EventHandler(this.shopItemList_SelectedIndexChanged);
            // 
            // shopDisplayTextBox
            // 
            this.shopDisplayTextBox.Location = new System.Drawing.Point(829, 27);
            this.shopDisplayTextBox.Multiline = true;
            this.shopDisplayTextBox.Name = "shopDisplayTextBox";
            this.shopDisplayTextBox.Size = new System.Drawing.Size(282, 123);
            this.shopDisplayTextBox.TabIndex = 15;
            // 
            // shopLbl
            // 
            this.shopLbl.AutoSize = true;
            this.shopLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.shopLbl.Location = new System.Drawing.Point(953, 9);
            this.shopLbl.Name = "shopLbl";
            this.shopLbl.Size = new System.Drawing.Size(35, 15);
            this.shopLbl.TabIndex = 16;
            this.shopLbl.Text = "Shop";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1123, 701);
            this.Controls.Add(this.shopLbl);
            this.Controls.Add(this.shopDisplayTextBox);
            this.Controls.Add(this.shopItemList);
            this.Controls.Add(this.BtnBuy);
            this.Controls.Add(this.enemiesList);
            this.Controls.Add(this.BtnWait);
            this.Controls.Add(this.txtEnemy);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.playerStatsTxt);
            this.Controls.Add(this.BtnAttack);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.BtnDown);
            this.Controls.Add(this.BtnRight);
            this.Controls.Add(this.BtnLeft);
            this.Controls.Add(this.BtnUp);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button BtnUp;
        private Button BtnLeft;
        private Button BtnRight;
        private Button BtnDown;
        private Label gMap;
        private Button BtnAttack;
        private TextBox playerStatsTxt;
        private Button BtnSave;
        private Button BtnLoad;
        private TextBox txtEnemy;
        private Button BtnWait;
        private ComboBox enemiesList;
        private Button BtnBuy;
        private ComboBox shopItemList;
        private TextBox shopDisplayTextBox;
        private Label shopLbl;
    }
}