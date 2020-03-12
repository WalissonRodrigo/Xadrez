using System;

namespace Xadrez.Board
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
