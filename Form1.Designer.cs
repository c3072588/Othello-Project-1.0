namespace Othello_Project_1._0
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
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            loadGameToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            exitGameToolStripMenuItem = new ToolStripMenuItem();
            ssettingToolStripMenuItem = new ToolStripMenuItem();
            speechToolStripMenuItem = new ToolStripMenuItem();
            infoPanelToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            BlackTokensLabel1 = new Label();
            WhiteTokensLabel2 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox5 = new PictureBox();
            lblMessage = new Label();
            Player1TextBox1 = new TextBox();
            Player2TextBox2 = new TextBox();
            StartGameButton1 = new Button();
            BlackLabel3 = new Label();
            WhiteLabel4 = new Label();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, ssettingToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(639, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, loadGameToolStripMenuItem, saveGameToolStripMenuItem, exitGameToolStripMenuItem });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(50, 20);
            gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(180, 22);
            newGameToolStripMenuItem.Text = "New Game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // loadGameToolStripMenuItem
            // 
            loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            loadGameToolStripMenuItem.Size = new Size(180, 22);
            loadGameToolStripMenuItem.Text = "Load Game";
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(180, 22);
            saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // exitGameToolStripMenuItem
            // 
            exitGameToolStripMenuItem.Name = "exitGameToolStripMenuItem";
            exitGameToolStripMenuItem.Size = new Size(180, 22);
            exitGameToolStripMenuItem.Text = "Exit Game";
            exitGameToolStripMenuItem.Click += exitGameToolStripMenuItem_Click;
            // 
            // ssettingToolStripMenuItem
            // 
            ssettingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { speechToolStripMenuItem, infoPanelToolStripMenuItem });
            ssettingToolStripMenuItem.Name = "ssettingToolStripMenuItem";
            ssettingToolStripMenuItem.Size = new Size(56, 20);
            ssettingToolStripMenuItem.Text = "Setting";
            // 
            // speechToolStripMenuItem
            // 
            speechToolStripMenuItem.Name = "speechToolStripMenuItem";
            speechToolStripMenuItem.Size = new Size(127, 22);
            speechToolStripMenuItem.Text = "Speech";
            // 
            // infoPanelToolStripMenuItem
            // 
            infoPanelToolStripMenuItem.Checked = true;
            infoPanelToolStripMenuItem.CheckState = CheckState.Checked;
            infoPanelToolStripMenuItem.Name = "infoPanelToolStripMenuItem";
            infoPanelToolStripMenuItem.Size = new Size(127, 22);
            infoPanelToolStripMenuItem.Text = "Info Panel";
            infoPanelToolStripMenuItem.Click += infoPanelToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gray;
            pictureBox1.Location = new Point(16, 528);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(586, 81);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // BlackTokensLabel1
            // 
            BlackTokensLabel1.AutoSize = true;
            BlackTokensLabel1.BackColor = Color.Gray;
            BlackTokensLabel1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            BlackTokensLabel1.Location = new Point(24, 550);
            BlackTokensLabel1.Name = "BlackTokensLabel1";
            BlackTokensLabel1.Size = new Size(46, 37);
            BlackTokensLabel1.TabIndex = 2;
            BlackTokensLabel1.Text = "2x";
            // 
            // WhiteTokensLabel2
            // 
            WhiteTokensLabel2.AutoSize = true;
            WhiteTokensLabel2.BackColor = Color.Gray;
            WhiteTokensLabel2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
            WhiteTokensLabel2.Location = new Point(337, 546);
            WhiteTokensLabel2.Name = "WhiteTokensLabel2";
            WhiteTokensLabel2.Size = new Size(46, 37);
            WhiteTokensLabel2.TabIndex = 3;
            WhiteTokensLabel2.Text = "2x";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkGreen;
            pictureBox2.Location = new Point(68, 546);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 48);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.DarkGreen;
            pictureBox4.Location = new Point(395, 544);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(48, 48);
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Black;
            pictureBox3.Location = new Point(72, 549);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.White;
            pictureBox5.Location = new Point(399, 548);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 40);
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(16, 37);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 11;
            // 
            // Player1TextBox1
            // 
            Player1TextBox1.Location = new Point(127, 546);
            Player1TextBox1.Name = "Player1TextBox1";
            Player1TextBox1.Size = new Size(100, 23);
            Player1TextBox1.TabIndex = 12;
            Player1TextBox1.Text = "Player1";
            Player1TextBox1.TextChanged += textBox1_TextChanged;
            // 
            // Player2TextBox2
            // 
            Player2TextBox2.Location = new Point(463, 544);
            Player2TextBox2.Name = "Player2TextBox2";
            Player2TextBox2.Size = new Size(100, 23);
            Player2TextBox2.TabIndex = 13;
            Player2TextBox2.Text = "Player2";
            Player2TextBox2.TextChanged += textBox2_TextChanged;
            // 
            // StartGameButton1
            // 
            StartGameButton1.Location = new Point(249, 555);
            StartGameButton1.Name = "StartGameButton1";
            StartGameButton1.Size = new Size(75, 23);
            StartGameButton1.TabIndex = 16;
            StartGameButton1.Text = "Start Game";
            StartGameButton1.UseVisualStyleBackColor = true;
            StartGameButton1.Click += button1_Click;
            // 
            // BlackLabel3
            // 
            BlackLabel3.AutoSize = true;
            BlackLabel3.Location = new Point(136, 577);
            BlackLabel3.Name = "BlackLabel3";
            BlackLabel3.Size = new Size(84, 15);
            BlackLabel3.TabIndex = 17;
            BlackLabel3.Text = "^NEXT TURN^";
            BlackLabel3.Click += label3_Click;
            // 
            // WhiteLabel4
            // 
            WhiteLabel4.AutoSize = true;
            WhiteLabel4.Location = new Point(470, 577);
            WhiteLabel4.Name = "WhiteLabel4";
            WhiteLabel4.Size = new Size(84, 15);
            WhiteLabel4.TabIndex = 18;
            WhiteLabel4.Text = "^NEXT TURN^";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(267, 269);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 19;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(639, 616);
            Controls.Add(label5);
            Controls.Add(WhiteLabel4);
            Controls.Add(BlackLabel3);
            Controls.Add(StartGameButton1);
            Controls.Add(Player2TextBox2);
            Controls.Add(Player1TextBox1);
            Controls.Add(lblMessage);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(WhiteTokensLabel2);
            Controls.Add(BlackTokensLabel1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem ssettingToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private PictureBox pictureBox1;
        private Label BlackTokensLabel1;
        private Label WhiteTokensLabel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem loadGameToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private ToolStripMenuItem speechToolStripMenuItem;
        private ToolStripMenuItem infoPanelToolStripMenuItem;
        private Label lblMessage;
        private TextBox Player1TextBox1;
        private TextBox Player2TextBox2;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button StartGameButton1;
        private Label BlackLabel3;
        private Label WhiteLabel4;
        private Label label5;
        private ToolStripMenuItem exitGameToolStripMenuItem;
    }
}