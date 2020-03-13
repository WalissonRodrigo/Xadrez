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
        private ChessMatch ChessMatch;
        public King(Board.Board board, Color color, ChessMatch chessMatch) : base(color, board)
        {
            ChessMatch = chessMatch;
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }

        private bool TowerCanExecuteEspecialMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Tower && piece.QtdMoves == 0 && piece.Color == Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);
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

            //#jogada especial roque
            if (QtdMoves == 0 && !ChessMatch.Xeque)
            {
                //#jogadaespecial Roque Pequeno
                Position towerPosition1 = new Position(Position.Line, Position.Column + 3);
                if (TowerCanExecuteEspecialMove(towerPosition1))
                {
                    Position position1 = new Position(Position.Line, Position.Column + 1);
                    Position position2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null)
                    {
                        matrix[Position.Line, Position.Column + 2] = true;
                    }
                }
                //#jogadaespecial Roque Grande
                Position towerPosition2 = new Position(Position.Line, Position.Column - 4);
                if (TowerCanExecuteEspecialMove(towerPosition2))
                {
                    Position position1 = new Position(Position.Line, Position.Column - 1);
                    Position position2 = new Position(Position.Line, Position.Column - 2);
                    Position position3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null && Board.Piece(position3) == null)
                    {
                        matrix[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return matrix;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
