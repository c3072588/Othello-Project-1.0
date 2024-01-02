using GameboardGUI;
using Othello_Project_1._0.Objects__Models_;
using System.CodeDom.Compiler;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Othello_Project_1._0
{
    public partial class Form1 : Form
    {
        GameboardImageArray _simpleBoard;
        private GameModelObject _game;
        public Form1()
        {
            InitializeComponent();

            Point topLeftConnerFromFormSides = new Point(0, 0);
            Point bottomRightConnerFromFormSides = new Point(100, 100);
            string pathToImages = Directory.GetCurrentDirectory() + @"\images\";

            _game = new GameModelObject("Walid", "Bob");

            UpdatePotentialMoves();

            List<int[]> potentialMoves = _game.LegalMoves();

            label3.Visible = false;
            label4.Visible = true;

            try
            {
                _simpleBoard = new GameboardImageArray(this, _game.Convert2DIntegerArray(), bottomRightConnerFromFormSides, bottomRightConnerFromFormSides, 0, pathToImages);
                _simpleBoard.TileClicked += new GameboardImageArray.TileClickedEventDelegate(BoardTileClicked);
                //_simpleBoard.TileClicked += new GameboardImageArray.(HighlightPotentialMoves);
                _simpleBoard.UpdateBoardGui(_game.Convert2DIntegerArray());

            }
            catch (Exception exception)
            {
                DialogResult result = MessageBox.Show(exception.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }
        }

        public void UpdatePotentialMoves() // double check if i or jacob wrote this , understand it properly 
        {
            for (int x = 0; x < _game.GameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < _game.GameBoard.GetLength(1); y++)
                {
                    if (_game.GameBoard[x, y] == TileState.PotentialMove)
                    {
                        _game.GameBoard[x, y] = TileState.Empty;
                    }
                }
            }

            List<int[]> LegalMoves = _game.LegalMoves();

            for (int i = 0; i < LegalMoves.Count; i++) // setting the potential moves into the GameBoard
            {
                int[] Position = LegalMoves[i];
                int PositionRow = Position[0];
                int PositionColumn = Position[1];
                _game.GameBoard[PositionRow, PositionColumn] = TileState.PotentialMove;
            }
        }

        private void BoardTileClicked(object sender, EventArgs e)
        {
            int clickedRowIndex = _simpleBoard.GetCurrentRowIndex(sender);
            int clickedColIndex = _simpleBoard.GetCurrentColumnIndex(sender);

            TileState originalValue = _game.GameBoard[clickedRowIndex, clickedColIndex];

            TileState CurrentTileState = _game.CurrentPlayer == GameState.Player1 ? TileState.Black : TileState.White;

            if (_game.CanGameContinue() == false)
            {
                EndGame();
                //NewGame();
            }


            if (originalValue == TileState.PotentialMove)
            {

                _game.FlippingTokens(clickedRowIndex, clickedColIndex);
                _game.GameBoard[clickedRowIndex, clickedColIndex] = CurrentTileState;


                CountPlayerTokens();
                CurrentPlayerTurn();
                _game.SwapPlayerTurn();
                CurrentPlayerTurn();
                UpdatePotentialMoves();

                _simpleBoard.UpdateBoardGui(_game.Convert2DIntegerArray());


                lblMessage.Text = $"You clicked the tile mapped to array position ({clickedRowIndex},{clickedColIndex}).\n" +
                    $"It's value used to be {originalValue}, but changed to {CurrentTileState} when you clicked the tile!";

            }
        }

        public void CountPlayerTokens() // counts how many tokens there are for each player/colour
        {
            int WhiteTokens = 0;
            int BlackTokens = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_game.GameBoard[i, j] == TileState.Black)
                    {
                        BlackTokens++;
                    }

                    else if (_game.GameBoard[i, j] == TileState.White)
                    {
                        WhiteTokens++;
                    }
                }
            }

            label1.Text = BlackTokens.ToString();
            label2.Text = WhiteTokens.ToString();

        }

        private void CurrentPlayerTurn()
        {
            // change the current player to the other player
            _game.CurrentPlayer = _game.CurrentPlayer == GameState.Player1 ? GameState.Player2 : GameState.Player1;
            label3.Visible = false;
            label4.Visible = false;

            if (_game.CurrentPlayer == GameState.Player1)
            {
                label3.Visible = false;
                label4.Visible = true;
            }

            else if (_game.CurrentPlayer == GameState.Player2)
            {
                label3.Visible = true;
                label4.Visible = false;
            }

        }

        public void EndGame()
        {
            int BlackScore = 0;
            int WhiteScore = 0;

            string Winner;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_game.GameBoard[i, j] == TileState.Black)
                    {
                        BlackScore++;
                    }

                    else if (_game.GameBoard[i, j] == TileState.White)
                    {
                        WhiteScore++;
                    }
                }
            }

            if (BlackScore > WhiteScore)
            {
                Winner = $"{textBox1.Text} (BLACK) wins!";
            }

            else if (WhiteScore > BlackScore)
            {
                Winner = $"{textBox2.Text} (WHITE) wins!";
            }

            else
            {
                Winner = "It's a tie!";
            }

            // Display the message to the players
            string message = $"Game Over!\nBLACK: {BlackScore}\nWHITE: {WhiteScore}\n{Winner}";
            MessageBox.Show(message, "Game Over", MessageBoxButtons.OK);


        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();

            DialogResult result = aboutForm.ShowDialog();
        }

        private void infoPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = !infoPanelToolStripMenuItem.Checked;
            label2.Visible = !infoPanelToolStripMenuItem.Checked;
            label3.Visible = !infoPanelToolStripMenuItem.Checked;
            label4.Visible = !infoPanelToolStripMenuItem.Checked;
            label5.Visible = !infoPanelToolStripMenuItem.Checked;
            textBox1.Visible = !infoPanelToolStripMenuItem.Checked;
            textBox2.Visible = !infoPanelToolStripMenuItem.Checked;

            pictureBox1.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox2.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox3.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox4.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox5.Visible = !infoPanelToolStripMenuItem.Checked;

            infoPanelToolStripMenuItem.Checked = !infoPanelToolStripMenuItem.Checked;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Disable textboxes after setting names
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            // Hide the start game button
            button1.Hide();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}