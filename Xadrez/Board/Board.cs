namespace Xadrez.Board
{
    /// <summary>
    /// Tabuleiro para Jogo de Xadrez.
    /// Possui um array de Peças que armazena todas as peças do jogo.
    /// Depende de Linhas e Colunas para determinar o tamanho do tabuleiro ao instanciar sua classe.
    /// Nenhuma peça pode movimentar fora dos limites do tabuleiro.
    /// </summary>
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        /// <summary>
        /// Retorna uma peça do tabuleiro usando index para linhas e colunas do tabuleiro.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Piece Piece(int line, int column)
        {
            if (line > Lines || column > Columns || line < 0 || column < 0)
                throw new BoardException("Posição escolhida não existe! Use as opções presentes na tela. Respeite o limite de linhas e colunas.");

            return pieces[line, column];
        }

        /// <summary>
        /// Retorna uma peça do tabuleiro usando a classe Posição que possui a linha e coluna da peça.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Piece Piece(Position position)
        {
            if (!PositionValidate(position))
                throw new BoardException("Posição escolhida não existe! Use as opções presentes na tela. Respeite o limite de linhas e colunas.");

            return pieces[position.Line, position.Column];
        }

        /// <summary>
        /// Verifica se existe alguma peça dentro do tabuleiro na posição informada como parâmetro.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool ExistsPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }
        /// <summary>
        /// Adiciona peças no tabuleiro.
        /// Deve informar qual peça e qual posição ela devera ocupar no tabuleiro
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="position"></param>
        public void AddPiece(Piece piece, Position position)
        {
            if (ExistsPiece(position))
                throw new BoardException("Já existe uma peça nessa posição!");
            pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        /// <summary>
        /// Remove uma peça do tabuleiro.
        /// Necessário informar a posição que a peça ocupa no tabuleiro.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
                return null;
            Piece piece = Piece(position);
            piece.Position = null;
            pieces[position.Line, position.Column] = null;
            return piece;
        }
        /// <summary>
        /// Valida a posição informada para que a posição ou jogada não seja inválida 
        /// ao realizar operação no tabuleiro
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool PositionValidate(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
                return false;
            return true;
        }

        /// <summary>
        /// Usa a Validação da Posição para gerar uma exeção caso uma posição inválida seja informada.
        /// </summary>
        /// <param name="position"></param>
        public void ValidatePosition(Position position)
        {
            if (!PositionValidate(position))
                throw new BoardException("Posição inválida!");
        }
    }
}
