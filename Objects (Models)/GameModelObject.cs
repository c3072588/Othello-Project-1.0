using GameboardGUI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;


namespace Othello_Project_1._0.Objects__Models_
{
    internal class GameModelObject
    {
        public TileState[,] GameBoard { get; set; }
        public GameState GameState { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public GameState CurrentPlayer { get; set; }

        // instanciating all objects and properties in our GameModelObject.cs
        public GameModelObject(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
            GameState = GameState.Player1;
            CurrentPlayer = GameState.Player1;
            GameBoard = new TileState[,] { { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.White , TileState.Black, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Black, TileState.White, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty },
                { TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty, TileState.Empty } };
        }

        public int[,] Convert2DIntegerArray()
        {
            int[,] intGameBoard = new int[8, 8];
            for (int i = 0; i < GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    intGameBoard[i, j] = (int)GameBoard[i, j]; 
                }
            }

            return intGameBoard;
        }

        public List<int[,]> CheckForTileState(TileState TileState) // checks for all tokens and adds them list
        {
            var TileCoordinates = new List<int[,]>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == TileState)
                    {
                        int[,] position = new int[1, 2]; // Create a 2D array to store the coordinates (i, j)
                        position[0, 0] = i; // Store the row (i) in the first element
                        position[0, 1] = j; // Store the column (j) in the second element
                        TileCoordinates.Add(position); // Adds the specific (i,j) position to the list
                    }
                }
            }
            return TileCoordinates ;
        }

        public List<int[]> CheckForOppositions(int Newx, int Newy, int dx, int dy)
        {
            List<int[]> Opps = new List<int[]>();
            List<int[]> PotentialMoves = new List<int[]>();
            TileState OpponentTileState = CurrentPlayer == GameState.Player1 ? TileState.White : TileState.Black;

            int NumberOfRows = GameBoard.GetLength(0);
            int NumberOfColumns = GameBoard.GetLength(1);

            int NEWX = Newx + dx; // x coordinate of the next square place after the first oppositional token
            int NEWY = Newy + dy; // y coordinate of the next square place after the first oppositional token

            if (NEWX >= 0 && NEWX < NumberOfRows && NEWY >= 0 && NEWY < NumberOfColumns)
            {
                if (GameBoard[NEWX, NEWY] == OpponentTileState)
                {
                    List<int[]> RecursiveOpps = CheckForOppositions(NEWX, NEWY, dx, dy); // checks if the next space in that direction is an opp 
                    Opps.AddRange(RecursiveOpps);
                }
                else if (GameBoard[NEWX, NEWY] == TileState.Empty) // if empty
                {
                    GameBoard[NEWX, NEWY] = TileState.PotentialMove;
                    int[] PotentialMove = { NEWX, NEWY };
                    PotentialMoves.Add(PotentialMove);
                }
            }

            return PotentialMoves;
        }



        public List<int[]> LegalMoves()
        {
            List<int[]> TotalPotentialMoves = new List<int[]>();

            int NumberOfRows = GameBoard.GetLength(0);
            int NumberOfColumns = GameBoard.GetLength(1);

            TileState CurrentTileState = CurrentPlayer == GameState.Player1 ? TileState.Black : TileState.White;
            TileState OpponentTileState = CurrentPlayer == GameState.Player1 ? TileState.White : TileState.Black;

            foreach (int[,] position in CheckForTileState(CurrentTileState))
            {
                int row = position[0, 0];
                int column = position[0, 1]; // could I just directly access this as position, since I've set position to be the complete (i,j) ?

                int[][] directions = new int[][]
                {
                    new int[] { -1, -1 },  // Up-Left
                    new int[] { -1, 0 },  // Up
                    new int[] { -1, 1 },  // Up-Right
                    new int[] { 0, -1 },  // Left
                    new int[] { 0, 1 },   // Right
                    new int[] { 1, -1 },  // Down-Left
                    new int[] { 1, 0 },   // Down
                    new int[] { 1, 1 }    // Down-Right
                };

                foreach (int[] direction in directions)
                {
                    int dx = direction[0]; // change in x
                    int dy = direction[1]; // change in y 

                    int NewX = row + dx; // new x coordinate
                    int NewY = column + dy; // new y coordinate

                    if (NewX >= 0 && NewX < NumberOfRows && NewY >= 0 && NewY < NumberOfColumns)
                    {
                        if (GameBoard[NewX, NewY] == OpponentTileState) // if any square around a given token is the opponent token
                        {
                            List<int[]> PotentialMoves = CheckForOppositions(NewX, NewY, dx, dy);
                            TotalPotentialMoves.AddRange(PotentialMoves);
                        }
                    }
                }
            }

            return TotalPotentialMoves;
        }


        public void FlipsTokens(int Newx, int Newy, int dx, int dy)
        {
            List<int[]> Opps = new List<int[]>
            {
                new int[] { Newx, Newy } // adds that FIRST opposition to opps list 
            };
            TileState CurrentTileState = CurrentPlayer == GameState.Player1 ? TileState.Black : TileState.White;
            TileState OpponentTileState = CurrentPlayer == GameState.Player1 ? TileState.White : TileState.Black;

            int NumberOfRows = GameBoard.GetLength(0);
            int NumberOfColumns = GameBoard.GetLength(1);

            int NEWX = Newx + dx; // x coordinate of the next square place after the first oppositional token
            int NEWY = Newy + dy; // y coordinate of the next square place after the first oppositional token

            while (NEWX >= 0 && NEWX < NumberOfRows && NEWY >= 0 && NEWY < NumberOfColumns && GameBoard[NEWX, NEWY] == OpponentTileState)
            {
                Opps.Add(new int[] { NEWX, NEWY });
                NEWX += dx;
                NEWY += dy;
            }

            if (NEWX >= 0 && NEWX < NumberOfRows && NEWY >= 0 && NEWY < NumberOfColumns && GameBoard[NEWX, NEWY] == CurrentTileState)
            {
                foreach (int[] Opp in Opps)
                {
                    GameBoard[Opp[0], Opp[1]] = CurrentTileState;
                }
            }
        }




        public void FlippingTokens(int row , int column)
        {
            int NumberOfRows = GameBoard.GetLength(0);
            int NumberOfColumns = GameBoard.GetLength(1);

            TileState CurrentTileState = CurrentPlayer == GameState.Player1 ? TileState.Black : TileState.White;
            TileState OpponentTileState = CurrentPlayer == GameState.Player1 ? TileState.White : TileState.Black;

            int[][] directions = new int[][]
            {
                new int[] { -1, -1 },  // Up-Left
                new int[] { -1, 0 },  // Up
                new int[] { -1, 1 },  // Up-Right
                new int[] { 0, -1 },  // Left
                new int[] { 0, 1 },   // Right
                new int[] { 1, -1 },  // Down-Left
                new int[] { 1, 0 },   // Down
                new int[] { 1, 1 }    // Down-Right
            };

            foreach (int[] direction in directions)
            {
                int dx = direction[0]; // change in x
                int dy = direction[1]; // change in y 

                int NewX = row + dx; // new x coordinate
                int NewY = column + dy; // new y coordinate

                if (NewX >= 0 && NewX < NumberOfRows && NewY >= 0 && NewY < NumberOfColumns)
                {
                    if (GameBoard[NewX, NewY] == OpponentTileState) // if any square around a given token is the opponent token , flip the tokens up to that opponent token
                    {
                        FlipsTokens(NewX, NewY, dx, dy);
                    }
                }
            }
        }

        public void SwapPlayerTurn()
        {
            CurrentPlayer = CurrentPlayer == GameState.Player1 ? GameState.Player2 : GameState.Player1;
            // if current player is black then opponent player is white , otherwise opponent player is black

        }


        public bool CanGameContinue()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // if the move is valid return true
                    if (GameBoard[i, j] == TileState.PotentialMove)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}