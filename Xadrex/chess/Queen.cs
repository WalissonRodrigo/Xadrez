using System;
using Xadrex.board;

namespace Xadrex.chess
{
    public class Queen : Piece
    {
        public Queen(Board board, Color color) : base(color, board)
        {

        }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
