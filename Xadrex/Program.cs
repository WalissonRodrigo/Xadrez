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
                    Console.Write("Digite a origem da jogada: ");
                    Position start = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Digite o destino da jogada: ");
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
