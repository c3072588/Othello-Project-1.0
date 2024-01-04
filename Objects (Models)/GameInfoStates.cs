using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_Project_1._0.Objects__Models_
{
     public class GameInfoStates
     {
        public TileState[,] GameBoard { get; set; }
        public GameState GameState { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public GameState CurrentPlayer { get; set; }

     }


}
