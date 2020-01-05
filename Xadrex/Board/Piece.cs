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
        public Position Position { get; set; }
        public Color Color { get; set; }
        public int QtdMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            QtdMoves = 0;
        }
    }
}
