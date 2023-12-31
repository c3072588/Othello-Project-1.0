using GameboardGUI;
using Newtonsoft.Json;
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

            // instantiate the actual game and set initial values of components 
            _game = new GameModelObject();

            UpdatePotentialMoves();

            List<int[]> potentialMoves = _game.LegalMoves();

            BlackLabel3.Visible = false;
            WhiteLabel4.Visible = true;

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
            // Clear existing potential moves on the game board
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

            for (int i = 0; i < LegalMoves.Count; i++) // setting all legal moves as potential moves into the GameBoard
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
                NewGame();
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

            BlackTokensLabel1.Text = BlackTokens.ToString();
            WhiteTokensLabel2.Text = WhiteTokens.ToString();
        }

        private void CurrentPlayerTurn() // change the current player to the other player
        {
            _game.CurrentPlayer = _game.CurrentPlayer == GameState.Player1 ? GameState.Player2 : GameState.Player1;
            BlackLabel3.Visible = false;
            WhiteLabel4.Visible = false;

            if (_game.CurrentPlayer == GameState.Player1)
            {
                BlackLabel3.Visible = false;
                WhiteLabel4.Visible = true;
            }

            else if (_game.CurrentPlayer == GameState.Player2)
            {
                BlackLabel3.Visible = true;
                WhiteLabel4.Visible = false;
            }

        }

        public void EndGame()
        {
            int blackScore = CountTiles(TileState.Black);
            int whiteScore = CountTiles(TileState.White);

            string winnerMessage = GetWinnerMessage(blackScore, whiteScore);

            string message = $"Game Over!\nBLACK: {blackScore}\nWHITE: {whiteScore}\n{winnerMessage}";
            MessageBox.Show(message, "Game Over", MessageBoxButtons.OK);
        }

        private int CountTiles(TileState tileState)
        {
            int count = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_game.GameBoard[i, j] == tileState)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private string GetWinnerMessage(int blackScore, int whiteScore)
        {
            if (blackScore > whiteScore)
            {
                return $"{Player1TextBox1.Text} is the winner :)";
            }
            else if (whiteScore > blackScore)
            {
                return $"{Player2TextBox2.Text} is the winner :)";
            }
            else
            {
                return $"Womp Womp, {Player1TextBox1.Text} and {Player2TextBox2.Text} drew :(";
            }
        }


        private void NewGame() // function which creates and sets a new game
        {
            if (_game.CanGameContinue())
            {
                DisplaySaveGameMessage();
            }

            _game.ResetGameBoard();
            ClearGameBoard();

           _game.SetInitialBoardState();

            _game.CurrentPlayer = GameState.Player1;
            CountPlayerTokens();
            UpdatePotentialMoves();

            _simpleBoard.UpdateBoardGui(_game.Convert2DIntegerArray());
            SetUpPlayerLabels();
        }

        private bool DisplaySaveGameMessage() // shows message asking user whether they want to save game or not 
        {
            DialogResult UserChoice = MessageBox.Show("Do you wish to save the current game state?", "Save Game", MessageBoxButtons.YesNo);

            if (UserChoice == DialogResult.Yes)
            {
                SaveGameState();
                return true;
            }
            return false;
        }

        private void ClearGameBoard()
        {
            _game.ClearGameBoard();
        }

        public void SetUpPlayerLabels() // Display player names
        {
            Player1TextBox1.Text = _game.Player1Name;
            Player2TextBox2.Text = _game.Player2Name;
        }

        //var SavedGameStates = new List<GameState>

        private void SaveGameState()
        {
            GameInfoStates newGameInfoStates = new GameInfoStates
            {
                Player1Name = Player1TextBox1.Text,
                Player2Name = Player2TextBox2.Text,
                CurrentPlayer = GameState.Player1,
                GameBoard = CopyGameBoard()
            };

            string jsonGameState = JsonConvert.SerializeObject(newGameInfoStates);

            try
            {
                File.WriteAllText("game_data.json", jsonGameState);
                MessageBox.Show("Game state saved successfully.", "Save Game");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game state: {ex.Message}", "Save Game Error");
            }
        }

        private TileState[,] CopyGameBoard()
        {
            TileState[,] copy = new TileState[8, 8];

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    copy[row, col] = _game.GameBoard[row, col];
                }
            }

            return copy;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Disable textboxes after setting names
            Player1TextBox1.ReadOnly = true;
            Player2TextBox2.ReadOnly = true;

            // Hide the start game button
            StartGameButton1.Hide();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_game.CanGameContinue())
            {
                bool UserWantsToSave = DisplaySaveGameMessage();

                if (UserWantsToSave)
                {
                    SaveGameState();
                }
            }
            
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();

            DialogResult result = aboutForm.ShowDialog();
        }

        public void infoPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlackTokensLabel1.Visible = !infoPanelToolStripMenuItem.Checked;
            WhiteTokensLabel2.Visible = !infoPanelToolStripMenuItem.Checked;
            BlackLabel3.Visible = !infoPanelToolStripMenuItem.Checked;
            WhiteLabel4.Visible = !infoPanelToolStripMenuItem.Checked;
            label5.Visible = !infoPanelToolStripMenuItem.Checked;
            Player1TextBox1.Visible = !infoPanelToolStripMenuItem.Checked;
            Player2TextBox2.Visible = !infoPanelToolStripMenuItem.Checked;

            pictureBox1.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox2.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox3.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox4.Visible = !infoPanelToolStripMenuItem.Checked;
            pictureBox5.Visible = !infoPanelToolStripMenuItem.Checked;

            infoPanelToolStripMenuItem.Checked = !infoPanelToolStripMenuItem.Checked;
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