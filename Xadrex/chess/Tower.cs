using System;
using Xadrex.board;

namespace Xadrex.chess
{
    public class Tower : Piece
    {
        public Tower(Board board, Color color) : base(color, board)
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
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.Line = pos.Line - 1;
            }

            //down
            pos.DefineValue(pos.Line + 1, pos.Column);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.Line = pos.Line + 1;
            }
            //right
            pos.DefineValue(pos.Line, pos.Column + 1);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.Column = pos.Column + 1;
            }
            //left
            pos.DefineValue(pos.Line, pos.Column - 1);
            while (Board.PositionValidate(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                    break;
                pos.Column = pos.Column-1;
            }
            
            return matrix;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
