using GameboardGUI;
using Othello_Project_1._0.Objects__Models_;

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

            _game = new GameModelObject( "Walid", "Bob");
            var test = _game.CanPlayerGo();

            List<int[]> potentialMoves = _game.CanPlayerGo();
            HighlightPotentialMoves(potentialMoves); //trying to show the potential moves on the screen

            try
            {
                _simpleBoard = new GameboardImageArray(this, _game.GameBoard, bottomRightConnerFromFormSides, bottomRightConnerFromFormSides, 0, pathToImages);
                _simpleBoard.TileClicked += new GameboardImageArray.TileClickedEventDelegate(BoardTileClicked);
                _simpleBoard.UpdateBoardGui(_game.GameBoard);

            }
            catch (Exception exception)
            {
                DialogResult result = MessageBox.Show(exception.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void BoardTileClicked(object sender, EventArgs e)
        {
            int clickedRowIndex = _simpleBoard.GetCurrentRowIndex(sender);
            int clickedColIndex = _simpleBoard.GetCurrentColumnIndex(sender);

            int flippedValue;
            int originalValue = _game.GameBoard[clickedRowIndex, clickedColIndex];
            if (originalValue == 0) flippedValue = 1;
            else flippedValue = 0;

            _game.GameBoard[clickedRowIndex, clickedColIndex] = flippedValue;
            _simpleBoard.UpdateBoardGui(_game.GameBoard);

            lblMessage.Text = $"You clicked the tile mapped to array position ({clickedRowIndex},{clickedColIndex}).\n" +
                $"It's value used to be {originalValue}, but changed to {flippedValue} when you clicked the tile!";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void HighlightPotentialMoves(List<int[]> TotalPotentialMoves) // functiion trying to get all potentaial moves and set them to '01'
        {
            foreach (var PotentialMove in TotalPotentialMoves)
            {
                int row = PotentialMove[0];
                int col = PotentialMove[1];
                _simpleBoard.SetTile(row, col, "01"); // Set a highlighted image
            }
        }
    }
}