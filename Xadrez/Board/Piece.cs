using System;

namespace Xadrez.Board
{
    /// <summary>
    /// Peça do Tabuleiro.
    /// Todas as peças respeitam locais ocupados por outras peças.
    /// Nenhuma peça que esteja defendendo um Rei pode ser movida deixando o Rei em situação de Xeque.
    /// </summary>
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMoves { get; protected set; }
        public Board Board { get; protected set; }
        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            QtdMoves = 0;
        }
        /// <summary>
        /// Incrementa um contador de movimentos para esta peça instânciada
        /// </summary>
        public void AddMoves()
        {
            QtdMoves++;
        }

        /// <summary>
        /// decrementa um contador de movimentos para esta peça instânciada
        /// </summary>
        public void RemoveMoves()
        {
            QtdMoves--;
        }
        /// <summary>
        /// Valida se existem movimentos possíveis para uma peça
        /// </summary>
        /// <returns></returns>
        public bool ExistPossibleMoves()
        {
            bool[,] matrix = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanPossibleMoveTo(Position position)
        {
            try
            {
                return PossibleMoves()[position.Line, position.Column];
            }
            catch (IndexOutOfRangeException ex)
            {
                //Console.WriteLine(ex.Message);
                throw new BoardException("Posição escolhida não existe! Use as opções presentes na tela. Respeite o limite de linhas e colunas.");
            }
        }

        /// <summary>
        /// Possíveis movimentos desta peça em questão.
        /// Este metodo é diferente para cada peça implementada.
        /// Consulte a classe da implementada para determinar seus movimentos possíveis.
        /// </summary>
        /// <returns></returns>
        public abstract bool[,] PossibleMoves();
    }
}
