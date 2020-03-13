using System;
using System.Collections.Generic;
using Xadrez.Board;
using Xadrez.Chess;

namespace Xadrez
{
    /// <summary>
    /// Responsável pelo controle do prompt de comando exibindo os dados da partida na tela.
    /// Mostra as peças e jogadas possíveis na tela para o usuário.
    /// Possui cores para diferenciar as peças.
    /// Têm nas bordas laterais e inferiores as opções para o jogador realizar suas jogadas e movimentar as peças.
    /// </summary>
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintPiecesCathed(match);
            Console.WriteLine();
            Console.WriteLine($"Turno: {match.Turn}");
            if (!match.Finish)
            {
                Console.WriteLine($"Aguardando Jogada: {match.CurrentPlayer.ToFriendlyString()}");
                if (match.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine($"Vencedor: {match.CurrentPlayer.ToFriendlyString()}");
            }
        }

        public static void PrintPiecesCathed(ChessMatch match)
        {
            Console.WriteLine();
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            PrintBlock(match.PiecesCatheds(Color.White));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintBlock(match.PiecesCatheds(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintBlock(HashSet<Piece> block)
        {
            Console.Write("[");
            foreach (Piece x in block)
            {
                Console.Write($"{x} ");
            }
            Console.Write("]");
        }
        /// <summary>
        /// Imprime o tabuleiro no console com as peças em seus respectivos lugares.
        /// </summary>
        /// <param name="board"></param>
        public static void PrintBoard(Board.Board board)
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

        /// <summary>
        /// Imprime o tabuleiro no console com as peças e os movimentos possíveis de uma peça
        /// </summary>
        /// <param name="board"></param>
        /// <param name="moves"></param>
        public static void PrintBoard(Board.Board board, bool[,] moves)
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
        /// <summary>
        /// Lê a posição de uma peça no xadrez e retornar em um formato válido para o jogo.
        /// </summary>
        /// <returns></returns>
        public static PositionChess ReadPositionChess()
        {
            try
            {
                string pos = Console.ReadLine();
                char column = pos[0];
                int line = int.Parse(pos[1].ToString());
                return new PositionChess(column, line);
            }
            catch
            {
                return new PositionChess('a', -1);
            }
        }
        /// <summary>
        /// Imprime uma peça no terminal exibindo a mesma.
        /// </summary>
        /// <param name="piece"></param>
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
