using System;
using System.Collections.Generic;
using System.Text;
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
        public ChessMatch()
        {
            Board = new Board.Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Pieces = new HashSet<Piece>();
            PiecesCathed = new HashSet<Piece>();
            AddPieces();
        }
        /// <summary>
        /// Realiza a movimentação das peças e troca o turno no fim.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void Move(Position start, Position end)
        {
            MovePiece(start, end);
            ChangeTurn();
        }
        /// <summary>
        /// Recebe a posição de inicial e final a ser movimentada
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void MovePiece(Position start, Position end)
        {
            Piece piece = Board.RemovePiece(start);
            piece.AddMoves();
            Piece pieceCathed = Board.RemovePiece(end);
            Board.AddPiece(piece, end);
            if (pieceCathed != null)
                PiecesCathed.Add(pieceCathed);
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
            foreach (Piece piece in PiecesCathed)
                if (piece.Color == color)
                    listPieces.Add(piece);
            listPieces.ExceptWith(PiecesCatheds(color));
            return listPieces;
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
            if (!Board.Piece(start).CanMoveTo(end))
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
        public void AddPieces()
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

            AddNewPiece(new Queen(Board, Color.Black), 'e', 8);
            AddNewPiece(new Queen(Board, Color.White), 'e', 1);

            AddNewPiece(new King(Board, Color.White), 'd', 1);
            AddNewPiece(new King(Board, Color.Black), 'd', 8);

            AddNewPiece(new Pawn(Board, Color.Black), 'a', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'b', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'c', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'd', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'e', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'f', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'g', 7);
            AddNewPiece(new Pawn(Board, Color.Black), 'h', 7);

            AddNewPiece(new Pawn(Board, Color.White), 'a', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'b', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'c', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'd', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'e', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'f', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'g', 2);
            AddNewPiece(new Pawn(Board, Color.White), 'h', 2);
            #endregion
        }
    }
}
