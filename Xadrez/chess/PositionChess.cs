using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.Board;

namespace Xadrez.Chess
{
    /// <summary>
    /// Classe para Converter a posição do tabuleiro físico de xadrex 
    /// para as posições da matrix da classe de posição
    /// </summary>
    class PositionChess
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public PositionChess(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
        public override string ToString()
        {
            return $"{Line}{Column}";
        }
    }
}
