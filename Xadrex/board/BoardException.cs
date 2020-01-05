using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrex.board
{
    class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {          
        }

        public BoardException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
