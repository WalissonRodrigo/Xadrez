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
            pos.DefineValue(Position.Line - 1, Position.Column - 1);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.DefineValue(pos.Line - 1, pos.Column - 1);
            }
            //up right
            pos.DefineValue(Position.Line - 1, Position.Column + 1);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.DefineValue(pos.Line - 1, pos.Column + 1);
            }

            //down right
            pos.DefineValue(Position.Line + 1, Position.Column + 1);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.DefineValue(pos.Line + 1, pos.Column + 1);
            }
            //down left
            pos.DefineValue(Position.Line + 1, Position.Column - 1);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.DefineValue(pos.Line + 1, pos.Column - 1);
            }
            return matrix;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
