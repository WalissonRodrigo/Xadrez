using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Board;

namespace Xadrez.Chess
{
    /// <summary>
    /// Partida de Xadrez. 
    /// Classe que inicializa a partida e controla os movimentos, turnos, regras e os ganhadores da partida. 
    /// </summary>
    public class ChessMatch
    {
        public Board.Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }
        public bool Xeque { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> PiecesCathed;
        public Piece VulnerableEnPassant { get; private set; }
        public ChessMatch()
        {
            Board = new Board.Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Xeque = false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            PiecesCathed = new HashSet<Piece>();
            AddPieces();
        }
        /// <summary>
        /// Realiza a movimentação das peças, verifica xeque e troca o turno no fim.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void PlayerValidTurn(Position start, Position end)
        {
            Piece pieceCathed = ExecuteMovePiece(start, end);
            if (PlayerInXeque(CurrentPlayer))
            {
                RollbackMovePiece(start, end, pieceCathed);
                throw new BoardException("Você não pode se colocar em xeque!");
            }
            Piece piece = Board.Piece(end);

            if (PlayerInXeque(ColorEnemy(CurrentPlayer)))
                Xeque = true;
            else
                Xeque = false;

            if (PlayerInXequeMate(ColorEnemy(CurrentPlayer)))
                Finish = true;
            else
                ChangeTurn();

            // #jogadaespecial en passant
            if (piece is Pawn && (end.Line == start.Line - 2 || end.Line == start.Line + 2))
            {
                VulnerableEnPassant = piece;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }
        /// <summary>
        /// Recebe a posição de inicial e final a ser movimentada
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private Piece ExecuteMovePiece(Position start, Position end)
        {
            Piece piece = Board.RemovePiece(start);
            piece.AddMoves();
            Piece pieceCathed = Board.RemovePiece(end);
            Board.AddPiece(piece, end);
            if (pieceCathed != null)
                PiecesCathed.Add(pieceCathed);

            // #jogadaespecial roque
            if (piece is King)
            {
                // #jogadaespecial roque pequeno
                if (start.Column + 2 == end.Column)
                {
                    Position startTower = new Position(start.Line, start.Column + 3);
                    Position endTower = new Position(start.Line, start.Column + 1);
                    Piece tower = Board.RemovePiece(startTower);
                    tower.AddMoves();
                    Board.AddPiece(tower, endTower);
                }
                // #jogadaespecial roque grande
                if (start.Column - 2 == end.Column)
                {
                    Position startTower = new Position(start.Line, start.Column - 4);
                    Position endTower = new Position(start.Line, start.Column - 1);
                    Piece tower = Board.RemovePiece(startTower);
                    tower.AddMoves();
                    Board.AddPiece(tower, endTower);
                }
            }

            // #jogadaespecial en passant
            if (piece is Pawn)
            {
                if (start.Column != end.Column && pieceCathed == null)
                {
                    Position posP;
                    if (piece.Color == Color.White)
                    {
                        posP = new Position(end.Line + 1, end.Column);
                    }
                    else
                    {
                        posP = new Position(end.Line - 1, end.Column);
                    }
                    pieceCathed = Board.RemovePiece(posP);
                    PiecesCathed.Add(pieceCathed);
                }
            }

            return pieceCathed;
        }

        /// <summary>
        /// Desfaz a jogada atual voltando as peças para seu devido lugar.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pieceCathed"></param>
        private void RollbackMovePiece(Position start, Position end, Piece pieceCathed)
        {
            Piece piece = Board.RemovePiece(end);
            piece.RemoveMoves();
            if (pieceCathed != null)
            {
                Board.AddPiece(pieceCathed, end);
                PiecesCathed.Remove(pieceCathed);
            }
            Board.AddPiece(piece, start);

            // #jogadaespecial roque
            if (piece is King)
            {
                // #jogadaespecial roque pequeno
                if (start.Column + 2 == end.Column)
                {
                    Position startTower = new Position(start.Line, start.Column + 3);
                    Position endTower = new Position(start.Line, start.Column + 1);
                    Piece tower = Board.RemovePiece(endTower);
                    tower.RemoveMoves();
                    Board.AddPiece(tower, startTower);
                }
                // #jogadaespecial roque grande
                if (start.Column - 2 == end.Column)
                {
                    Position startTower = new Position(start.Line, start.Column - 4);
                    Position endTower = new Position(start.Line, start.Column - 1);
                    Piece tower = Board.RemovePiece(endTower);
                    tower.RemoveMoves();
                    Board.AddPiece(tower, startTower);
                }
            }

            // #jogadaespecial en passant
            if (piece is Pawn)
            {
                if (start.Column != end.Column && pieceCathed == VulnerableEnPassant)
                {
                    Piece pawn = Board.RemovePiece(end);
                    Position posP;
                    if (piece.Color == Color.White)
                    {
                        posP = new Position(3, end.Column);
                    }
                    else
                    {
                        posP = new Position(4, end.Column);
                    }
                    Board.AddPiece(pawn, posP);
                }
            }
        }
        /// <summary>
        /// Retorna as Peças Capturadas de uma determinada Cor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesCatheds(Color color)
        {
            HashSet<Piece> listPieces = new HashSet<Piece>();
            foreach (Piece piece in PiecesCathed)
                if (piece.Color == color)
                    listPieces.Add(piece);
            return listPieces;
        }

        /// <summary>
        /// Retorna as Peças Capturadas em uma determinada partida
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> listPieces = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
                if (piece.Color == color)
                    listPieces.Add(piece);
            listPieces.ExceptWith(PiecesCatheds(color));
            return listPieces;
        }

        private Color ColorEnemy(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }
        /// <summary>
        /// Retorna um Rei de uma determinada Cor da lista de Peças no Jogo.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Piece King(Color color)
        {
            foreach (Piece king in PiecesInGame(color))
            {
                if (king is King)
                    return king;
            }
            return null;
        }
        /// <summary>
        /// Verifica se o rei de uma determinada Cor está em situação de xeque.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool PlayerInXeque(Color color)
        {
            Piece king = King(color);
            if (king == null)
                throw new BoardException($"Não existe um rei da cor {color.ToFriendlyString()} no tabuleiro!");
            var piecies = PiecesInGame(ColorEnemy(color));
            foreach (Piece piece in piecies)
            {
                bool[,] matrix = piece.PossibleMoves();
                if (matrix[king.Position.Line, king.Position.Column])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifique se o jogador de uma determinada Cor não levou um xeque mate
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool PlayerInXequeMate(Color color)
        {
            if (!PlayerInXeque(color))
                return false;
            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] matrix = piece.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position positionStart = piece.Position;
                            Position positionEnd = new Position(i, j);
                            Piece pieceCathed = ExecuteMovePiece(positionStart, positionEnd);
                            bool playerInXeque = PlayerInXeque(color);
                            RollbackMovePiece(positionStart, positionEnd, pieceCathed);
                            if (!playerInXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }
        public void ValidPositionStart(Position position)
        {
            if (Board.Piece(position) == null)
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            if (CurrentPlayer != Board.Piece(position).Color)
                throw new BoardException($"A peça de origem escolhida não é sua! Você joga com peças {CurrentPlayer.ToFriendlyString()}");
            if (!Board.Piece(position).ExistPossibleMoves())
                throw new BoardException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void ValidPositionEnd(Position start, Position end)
        {
            if (!Board.Piece(start).CanPossibleMoveTo(end))
                throw new BoardException("Posição de Destino inválida");
        }
        private void ChangeTurn()
        {
            Turn++;
            if (CurrentPlayer == Color.White)
                CurrentPlayer = Color.Black;
            else
                CurrentPlayer = Color.White;
        }

        public void AddNewPiece(Piece piece, char column, int line)
        {
            Board.AddPiece(piece, new PositionChess(column, line).ToPosition());
            Pieces.Add(piece);
        }
        /// <summary>
        /// Adiciona várias Peças no Tabuleiro.
        /// É usada para inicializar o Tabuleiro com todas as peças na ordem inicial de novas partidas
        /// </summary>
        private void AddPieces()
        {
            #region Todas as Peças
            AddNewPiece(new Tower(Board, Color.Black), 'a', 8);
            AddNewPiece(new Tower(Board, Color.Black), 'h', 8);
            AddNewPiece(new Tower(Board, Color.White), 'a', 1);
            AddNewPiece(new Tower(Board, Color.White), 'h', 1);

            AddNewPiece(new Horse(Board, Color.Black), 'b', 8);
            AddNewPiece(new Horse(Board, Color.Black), 'g', 8);
            AddNewPiece(new Horse(Board, Color.White), 'b', 1);
            AddNewPiece(new Horse(Board, Color.White), 'g', 1);

            AddNewPiece(new Bishop(Board, Color.Black), 'c', 8);
            AddNewPiece(new Bishop(Board, Color.Black), 'f', 8);
            AddNewPiece(new Bishop(Board, Color.White), 'c', 1);
            AddNewPiece(new Bishop(Board, Color.White), 'f', 1);

            AddNewPiece(new King(Board, Color.Black, this), 'e', 8);
            AddNewPiece(new King(Board, Color.White, this), 'e', 1);

            AddNewPiece(new Queen(Board, Color.Black), 'd', 8);
            AddNewPiece(new Queen(Board, Color.White), 'd', 1);

            AddNewPiece(new Pawn(Board, Color.Black, this), 'a', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'b', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'c', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'd', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'e', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'f', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'g', 7);
            AddNewPiece(new Pawn(Board, Color.Black, this), 'h', 7);

            AddNewPiece(new Pawn(Board, Color.White, this), 'a', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'b', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'c', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'd', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'e', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'f', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'g', 2);
            AddNewPiece(new Pawn(Board, Color.White, this), 'h', 2);
            #endregion
        }
    }
}
