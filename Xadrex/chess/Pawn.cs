using Xadrex.board;

namespace Xadrex.chess
{
    public class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(color, board)
        {

        }

        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
