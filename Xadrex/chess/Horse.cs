using System;
using System.Collections.Generic;
using System.Text;
using Xadrex.board;

namespace Xadrex.chess
{
    public class Horse : Piece
    {
        public Horse(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "C";
        }
    }
}
