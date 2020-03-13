using System;
using Xadrez.Board;
using Xadrez.Chess;

namespace Xadrez
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Xadrez";
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.Finish)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position start = Screen.ReadPositionChess().ToPosition();
                        match.ValidPositionStart(start);

                        bool[,] possiblesMoves = match.Board.Piece(start).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblesMoves);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position end = Screen.ReadPositionChess().ToPosition();
                        match.ValidPositionEnd(start, end);

                        match.PlayerValidTurn(start, end);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\n");
        }
    }
}
