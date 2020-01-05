using System;
using Xadrex.board;
using Xadrex.chess;

namespace Xadrex
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Title = "Xadrex";
                Console.ForegroundColor = ConsoleColor.White;
                Board board = new Board(8, 8);
                board.AddPiece(new Tower(board, Color.Black), new PositionChess('a', 8).ToPosition());
                board.AddPiece(new Tower(board, Color.Black), new PositionChess('h', 8).ToPosition());
                board.AddPiece(new King(board, Color.White), new PositionChess('d', 1).ToPosition());
                board.AddPiece(new Queen(board, Color.White), new PositionChess('e', 1).ToPosition());
                Screen.PrintBoard(board);

                Console.WriteLine();

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
