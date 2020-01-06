using Xadrex.board;

namespace Xadrex.chess
{
    public class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(color, board)
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
