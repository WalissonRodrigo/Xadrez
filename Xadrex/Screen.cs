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
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
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
            if(piece.Color == Color.White)
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
        }
    }
}
