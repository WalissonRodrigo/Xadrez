using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrex.board
{
    /// <summary>
    /// Peça do Tabuleiro
    /// </summary>
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int qtdMoves { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            this.position = position;
            this.color = color;
            this.board = board;
            qtdMoves = 0;
        }
    }
}
