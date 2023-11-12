using GameboardGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Othello_Project_1._0.Objects__Models_
{
    internal class GameModelObject
    {
        public int[,] GameBoard { get; set; }
        public GameState GameState { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public List<int[,]> BlackTokens { get; private set; }
        public List<int[,]> WhiteTokens { get; private set; }

        // instanciating all objects and properties in our GameModelObject.cs
        public GameModelObject(string player1Name, string player2Name)
        {
            Player1Name = player1Name;
            Player2Name = player2Name;
            GameState = GameState.Player1;
            GameBoard = new int[,] { { 10, 10, 10, 10, 10, 10, 10, 10 }, { 10, 10, 10, 10, 10, 10, 10, 10 },
            { 10, 10, 10, 10, 10, 10, 10, 10 }, { 10, 10, 10, 1, 0, 10, 10, 10 },
            { 10, 10, 10, 0, 1, 10, 10, 10, }, { 10, 10, 10, 10, 10, 10, 10, 10 },
            { 10, 10, 10, 10, 10, 10, 10, 10 },{ 10, 10, 10, 10, 10, 10, 10, 10 } };
            BlackTokens = new List<int[,]>();
            WhiteTokens = new List<int[,]>();
        }

        public List<int[,]> CheckForBlack() // checks for all black tokens and adds them to list
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == 0)
                    {
                        int[,] position = new int[1, 2]; // Create a 2D array to store the coordinates (i, j)
                        position[0, 0] = i; // Store the row (i) in the first element
                        position[0, 1] = j; // Store the column (j) in the second element
                        BlackTokens.Add(position); // Adds the specific (i,j) position to the Black list
                    }
                }
            }
            return BlackTokens;
        }
        public List<int[,]> CheckForWhite() // checks for all white tokens and adds them to list
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (GameBoard[i, j] == 1)
                    {
                        int[,] position = new int[1, 2]; // Create a 2D array to store the coordinates (i, j)
                        position[0, 0] = i; // Store the row (i) in the first element
                        position[0, 1] = j; // Store the column (j) in the second element
                        WhiteTokens.Add(position); // Adds the specific (i,j) the position to the Black list
                    }
                }
            }
            return WhiteTokens;
        }

        public List<int[]> CheckForOppositionalWhites(int Newx, int Newy, int dx, int dy) //checks if the next square is a oppositional white token (when blacks turn)
        {
            List<int[]> Opps = new List<int[]>();
            List<int[]> PotentialMoves = new List<int[]>();

            int NEWX = Newx + dx; // x coordinate of next square place after first oppositional token
            int NEWY = Newy + dy; // y coordinate of next square place after first oppositional token
            int[] OppCoordinates = { NEWX, NEWY };

            Opps.Add(OppCoordinates); // adds (x,y) coordinate to list

            if (GameBoard[NEWX, NEWY] == 1) // if white
            {
                CheckForOppositionalWhites(NEWX, NEWY, dx, dy); // check if the next space in that direction is an opp 
            }

            else if (GameBoard[NEWX, NEWY] == 10) // if empty
            {
                int[] PotentialMove = { NEWX, NEWY };
                PotentialMoves.Add(PotentialMove);
            }

            else // if black
            {
                //end -> decide whether this means i delete all elements in the Opps list ,
                //or delete the list etc. what do i do? 
            }

            return PotentialMoves;
        }

        public List<int[]> CheckForOppositionalBlacks(int Newx, int Newy, int dx, int dy) //checks if the next square is a oppositional black token (when white turn)
        {
            List<int[]> Opps = new List<int[]>();
            List<int[]> PotentialMoves = new List<int[]>();


            int NEWX = Newx + dx; // x coordinate of next square place after first oppositional token
            int NEWY = Newy + dy; // y coordinate of next square place after first oppositional token
            int[] OppCoordinates = { NEWX, NEWY };

            Opps.Add(OppCoordinates); // adds (x,y) coordinate to list

            if (GameBoard[NEWX, NEWY] == 0) // if black
            {
                CheckForOppositionalBlacks(NEWX, NEWY, dx, dy); // check if there are more consecutive oppositional white tokens in that direction.
            }

            else if (GameBoard[NEWX, NEWY] == 10) // if empty 
            {
                int[] PotentialMove = { NEWX, NEWY };
                PotentialMoves.Add(PotentialMove);
                GameBoard[NEWX, NEWY] = 01;
                // display possible square on empty space 
            }

            else // if white
            {
                //end -> decide whether this means i delete all elements in the Opps list ,
                //or delete the list etc. what do i do? 
            }

            return PotentialMoves;
        }

        public List<int[]> CanPlayerGo(/*TileState, int row , int column, GameState CurrentPlayer*/)
        {
            // if current player is black then opponent player is white , otherwise opponent player is black
            // GameState OpponentPlayer = CurrentPlayer == GameState.Player1 ? GameState.Player2 : GameState.Player1;
            List<int[]> TotalPotentialMoves = new List<int[]>();

            int NumberOfRows = GameBoard.GetLength(0);
            int NumberOfColumns = GameBoard.GetLength(1);

            foreach (int[,] position in BlackTokens) 
            {
                int row = position[0, 0];
                int column = position[0, 1]; // could i just directly access this as position, since i've set position to be the complete (i,j) ?

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
                        if ( /*GameState == 0 &&*/ GameBoard[NewX, NewY] == 1) // if any square around a given black token is white
                        {
                            List<int[]> BlacksPotentialMoves = CheckForOppositionalWhites(NewX, NewY, dx, dy);
                            TotalPotentialMoves.AddRange(BlacksPotentialMoves);
                        }

                        else
                        {
                            //end 
                        }
                    }
                }
            }

            foreach (int[,] position in WhiteTokens) 
            {
                int row = position[0, 0];
                int column = position[0, 1]; // could i just directly access this as position, since i've set position to be the complete (i,j)

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

                    int NewX = row + dx;
                    int NewY = column + dy;

                    if (NewX >= 0 && NewX < NumberOfRows && NewY >= 0 && NewY < NumberOfColumns)
                    {
                        if ( /*GameState == 1 &&*/ (GameBoard[NewX, NewY] == 0)) // if any square around a given token is black
                        {
                            List<int[]> WhitesPotentialMoves = CheckForOppositionalBlacks(NewX, NewY, dx, dy);
                            TotalPotentialMoves.AddRange(WhitesPotentialMoves);
                        }

                        else
                        {
                            // end
                        }
                    }
                }
            }

            return TotalPotentialMoves;
        }
    }
}


/*  for (int i = 0; i < Opps.Count ; i++)    this code will be fore iterating through the opps list, accessing that element and changing it to ur colour 
      {
         Opps[i] = 
      } */ 