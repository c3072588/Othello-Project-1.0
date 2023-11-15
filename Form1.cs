using GameboardGUI;
using Othello_Project_1._0.Objects__Models_;
using System.CodeDom.Compiler;
using System.Diagnostics.Eventing.Reader;
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

            if (originalValue == TileState.PotentialMove )
            {
                _game.FlippingTokens(clickedRowIndex, clickedColIndex);
                _game.GameBoard[clickedRowIndex, clickedColIndex] = CurrentTileState;

                _game.SwapPlayerTurn();

                UpdatePotentialMoves();
                _simpleBoard.UpdateBoardGui(_game.Convert2DIntegerArray());

                lblMessage.Text = $"You clicked the tile mapped to array position ({clickedRowIndex},{clickedColIndex}).\n" +
                    $"It's value used to be {originalValue}, but changed to {CurrentTileState} when you clicked the tile!";

            }

            /*Public swap()
            int temp = current
            int current = next
            int next = temp */


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}