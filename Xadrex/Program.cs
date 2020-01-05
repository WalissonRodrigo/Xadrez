using System;
using Xadrex.board;
using Xadrex.chess;

namespace Xadrex
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Xadrex";
            Board board = new Board(8, 8);
            board.AddPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.AddPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.AddPiece(new King(board, Color.White), new Position(2, 4));
            Screen.PrintBoard(board);
            Console.ReadLine();
        }
    }
}
