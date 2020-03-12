using Xadrez.Board;

namespace Xadrez.Chess
{
    public class Pawn : Piece
    {
        /// <summary>
        /// Peça Peão. Pode mover sempre para frente. 
        /// Na saída pode andar duas casas mas após o primeiro movimento pode mover uma casa por turno. 
        /// Possui Jogadas especiais como Roque, Empasante.
        /// </summary>
        public Pawn(Board.Board board, Color color) : base(color, board)
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
            Piece piece = Board.Piece(Position);
            if (piece.QtdMoves == 0)
            {
                //up + 2
                pos.DefineValue(Position.Line - 2, Position.Column);
                if (Board.PositionValidate(pos) && CanMove(pos))
                    matrix[pos.Line, pos.Column] = true;
                //down + 2
                pos.DefineValue(Position.Line + 2, Position.Column);
                if (Board.PositionValidate(pos) && CanMove(pos))
                    matrix[pos.Line, pos.Column] = true;
            }
            //down
            if (piece.Color == Color.Black)
            {
                pos.DefineValue(Position.Line + 1, Position.Column);
                if (Board.PositionValidate(pos) && CanMove(pos))
                    matrix[pos.Line, pos.Column] = true;
            }
            //up
            if (piece.Color == Color.White)
            {
                pos.DefineValue(Position.Line - 1, Position.Column);
                if (Board.PositionValidate(pos) && CanMove(pos))
                    matrix[pos.Line, pos.Column] = true;
            }
            return matrix;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
