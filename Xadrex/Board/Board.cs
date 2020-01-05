using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrex.board
{
    /// <summary>
    /// Tabuleiro para Jogo de Xadrex
    /// </summary>
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.Line, position.Column];
        }

        public bool ExistsPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }
        public void AddPiece(Piece piece, Position position)
        {
            if (ExistsPiece(position))
                throw new BoardException("Já existe uma peça nessa posição!");
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
                return null;
            Piece piece = Piece(position);
            piece.Position = null;
            pieces[position.Line, position.Column] = null;
            return piece;
        }
        public bool PositionValidate(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
                return false;
            return true;
        }
        public void ValidatePosition(Position position)
        {
            if (!PositionValidate(position))
                throw new BoardException("Posição inválida!");
        }
    }
}
