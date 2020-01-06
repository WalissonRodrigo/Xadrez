using System;
using System.Collections.Generic;
using System.Text;
using Xadrex.board;
using Xadrex.chess;

namespace Xadrex
{
    class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("  a b c d e f g h");
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void PrintBoard(Board board, bool[,] moves)
        {
            ConsoleColor backgroundCurrent = Console.BackgroundColor;
            ConsoleColor backgroundChanged = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Lines; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < board.Columns; j++)
                {
                    if (moves[i, j])
                        Console.BackgroundColor = backgroundChanged;
                    else
                        Console.BackgroundColor = backgroundCurrent;
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = backgroundCurrent;
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("  a b c d e f g h");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static PositionChess ReadPositionChess()
        {
            string pos = Console.ReadLine();
            char column = pos[0];
            int line = int.Parse(pos[1].ToString());
            return new PositionChess(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
                Console.Write("- ");
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor colorConsole = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = colorConsole;
                }
                Console.Write(" ");
            }
        }
    }
}
