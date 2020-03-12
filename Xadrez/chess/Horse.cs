using Xadrez.Board;

namespace Xadrez.Chess
{
    /// <summary>
    /// Peça Cavalo. Move em formato de L pulando peças mas respeitando locais ocupados ou inválidos.
    /// </summary>
    public class Horse : Piece
    {
        public Horse(Board.Board board, Color color) : base(color, board)
        {

        }

        public override bool[,] PossibleMoves()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
