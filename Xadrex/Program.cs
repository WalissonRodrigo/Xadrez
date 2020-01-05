using System;
using Xadrex.board;

namespace Xadrex
{
    class Program
    {
        static void Main()
        {
            Position P;
            P = new Position(3, 4);
            Console.WriteLine($"Position: {P}");

            Board board = new Board(8, 8);
            Console.WriteLine(board);
        }
    }
}
