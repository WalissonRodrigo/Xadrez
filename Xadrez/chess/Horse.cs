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
        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);
            //up left
            pos.DefineValue(Position.Line - 1, Position.Column - 2);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //up right
            pos.DefineValue(Position.Line - 2, Position.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //right
            pos.DefineValue(Position.Line - 2, Position.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down right
            pos.DefineValue(Position.Line - 1, Position.Column + 2);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down
            pos.DefineValue(Position.Line + 1, Position.Column + 2);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down left
            pos.DefineValue(Position.Line + 2, Position.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //left
            pos.DefineValue(Position.Line + 2, Position.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //up left
            pos.DefineValue(Position.Line + 1, Position.Column - 2);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            return matrix;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
