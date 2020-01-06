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
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finish)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                   
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position start = Screen.ReadPositionChess().ToPosition();

                    bool[,] possiblesMoves = match.Board.Piece(start).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblesMoves);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position end = Screen.ReadPositionChess().ToPosition();

                    match.Move(start, end);
                }

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
