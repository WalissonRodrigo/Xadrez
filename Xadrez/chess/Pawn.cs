using Xadrez.Board;

namespace Xadrez.Chess
{
    public class Pawn : Piece
    {
        private ChessMatch ChessMatch;

        /// <summary>
        /// Peça Peão. Pode mover sempre para frente. 
        /// Na saída pode andar duas casas mas após o primeiro movimento pode mover uma casa por turno. 
        /// Possui Jogadas especiais como Roque, Empasante.
        /// </summary>
        public Pawn(Board.Board board, Color color, ChessMatch chessMatch) : base(color, board)
        {
            ChessMatch = chessMatch;
        }

        private bool Empty(Position position)
        {
            return Board.Piece(position) == null;
        }
        private bool HaveEnemy(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];
            Position pos = new Position(0, 0);
            Piece piece = Board.Piece(Position);
            if (Color == Color.White)
            {
                pos.DefineValue(Position.Line - 1, Position.Column);
                if (Board.PositionValidate(pos) && Empty(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.PositionValidate(p2) && Empty(p2) && Board.PositionValidate(pos) && Empty(pos) && QtdMoves == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line - 1, Position.Column - 1);
                if (Board.PositionValidate(pos) && HaveEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line - 1, Position.Column + 1);
                if (Board.PositionValidate(pos) && HaveEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.PositionValidate(left) && HaveEnemy(left) && Board.Piece(left) == ChessMatch.VulnerableEnPassant)
                    {
                        matrix[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.PositionValidate(right) && HaveEnemy(right) && Board.Piece(right) == ChessMatch.VulnerableEnPassant)
                    {
                        matrix[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.DefineValue(Position.Line + 1, Position.Column);
                if (Board.PositionValidate(pos) && Empty(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.PositionValidate(p2) && Empty(p2) && Board.PositionValidate(pos) && Empty(pos) && QtdMoves == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line + 1, Position.Column - 1);
                if (Board.PositionValidate(pos) && HaveEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line + 1, Position.Column + 1);
                if (Board.PositionValidate(pos) && HaveEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.PositionValidate(left) && HaveEnemy(left) && Board.Piece(left) == ChessMatch.VulnerableEnPassant)
                    {
                        matrix[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.PositionValidate(right) && HaveEnemy(right) && Board.Piece(right) == ChessMatch.VulnerableEnPassant)
                    {
                        matrix[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return matrix;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
