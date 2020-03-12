using System;
using Xadrez.Board;

namespace Xadrez.Chess
{
    /// <summary>
    /// Peça Rei. Pode mover em qualquer direção mas apenas uma casa.
    /// Um Rei nunca pode mover para uma posição que deixe-o em situação de xeque.
    /// </summary>
    public class King : Piece
    {
        public King(Board.Board board, Color color) : base(color, board)
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
            pos.DefineValue(Position.Line - 1, Position.Column);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //up right
            pos.DefineValue(Position.Line - 1, Position.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //right
            pos.DefineValue(Position.Line, Position.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down right
            pos.DefineValue(Position.Line + 1, Position.Column + 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down
            pos.DefineValue(Position.Line + 1, Position.Column);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //down left
            pos.DefineValue(Position.Line + 1, Position.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //left
            pos.DefineValue(Position.Line, Position.Column - 1);
            if (Board.PositionValidate(pos) && CanMove(pos))
                matrix[pos.Line, pos.Column] = true;
            //up left
            pos.DefineValue(Position.Line - 1, Position.Column - 1);
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
