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
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[this.lines, this.columns];
        }
    }
}
