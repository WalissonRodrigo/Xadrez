using System;
using Xadrex.board;

namespace Xadrex.chess
{
    public class King : Piece
    {
        public King(Board board, Color color) : base(color, board)
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
            Position pos = new Position(0,0);
            //up
            pos.DefineValue(pos.Line - 1, pos.Column);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //up right
            pos.DefineValue(pos.Line - 1, pos.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //right
            pos.DefineValue(pos.Line, pos.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down right
            pos.DefineValue(pos.Line + 1, pos.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down
            pos.DefineValue(pos.Line + 1, pos.Column);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down left
            pos.DefineValue(pos.Line + 1, pos.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //left
            pos.DefineValue(pos.Line, pos.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //up left
            pos.DefineValue(pos.Line - 1, pos.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            return matrix;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
