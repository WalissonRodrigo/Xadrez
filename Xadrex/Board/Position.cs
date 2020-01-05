﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrex.board
{
    /// <summary>
    /// Posição de uma Peça no Tabuleiro
    /// </summary>
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position()
        {
        }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Line}, {Column}";
        }
    }
}
