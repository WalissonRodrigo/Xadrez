namespace Xadrex.board
{
    /// <summary>
    /// Peça do Tabuleiro
    /// </summary>
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int QtdMoves { get; protected set; }
        public Board Board { get; protected set; }
        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            QtdMoves = 0;
        }
        public void AddMoves()
        {
            QtdMoves++;
        }
        public abstract bool[,] PossibleMoves();
    }
}
