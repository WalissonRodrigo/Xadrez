using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrex.board
{
    /// <summary>
    /// Tabuleiro para Jogo de Xadrex ou outros jogos.
    /// </summary>
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }
    }
}
