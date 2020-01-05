using System;
using Xadrex.board;

namespace Xadrex
{
    class Program
    {
        static void Main()
        {
            Board board = new Board(8, 8);
            Screen.PrintBoard(board);
            Console.ReadLine();
        }
    }
}
