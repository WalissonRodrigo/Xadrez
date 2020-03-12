using Xadrez.Board;

namespace Xadrez.Chess
{
    /// <summary>
    /// Peça Bispo. Pode mover em diagonais.
    /// </summary>
    public class Bishop : Piece
    {
        public Bishop(Board.Board board, Color color) : base(color, board)
        {

        }

        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
