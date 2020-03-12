using System;
using Xadrez.Board;

namespace Xadrez.Chess
{
    /// <summary>
    /// Peça Rainha. Pode mover em linhas retas ou diagonais.
    /// </summary>
    public class Queen : Piece
    {
        public Queen(Board.Board board, Color color) : base(color, board)
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
