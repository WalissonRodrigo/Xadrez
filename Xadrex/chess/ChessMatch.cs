using System;
using System.Collections.Generic;
using System.Text;
using Xadrex.board;

namespace Xadrex.chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finish { get; private set; }
        public ChessMatch()
        {
            Board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            Finish = false;
            AddPieces();
        }

        public void Move(Position start, Position end)
        {
            Piece piece = Board.RemovePiece(start);
            piece.AddMoves();
            Piece pieceCathed = Board.RemovePiece(end);
            Board.AddPiece(piece, end);
        }

        public void AddPieces()
        {
            //Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('a', 8).ToPosition());
            //Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('h', 8).ToPosition());
            //Board.AddPiece(new Tower(Board, Color.White), new PositionChess('a', 1).ToPosition());
            //Board.AddPiece(new Tower(Board, Color.White), new PositionChess('h', 1).ToPosition());

            //Board.AddPiece(new Horse(Board, Color.Black), new PositionChess('b', 8).ToPosition());
            //Board.AddPiece(new Horse(Board, Color.Black), new PositionChess('g', 8).ToPosition());
            //Board.AddPiece(new Horse(Board, Color.White), new PositionChess('b', 1).ToPosition());
            //Board.AddPiece(new Horse(Board, Color.White), new PositionChess('g', 1).ToPosition());

            //Board.AddPiece(new Bishop(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            //Board.AddPiece(new Bishop(Board, Color.Black), new PositionChess('f', 8).ToPosition());
            //Board.AddPiece(new Bishop(Board, Color.White), new PositionChess('c', 1).ToPosition());
            //Board.AddPiece(new Bishop(Board, Color.White), new PositionChess('f', 1).ToPosition());

            //Board.AddPiece(new Queen(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            //Board.AddPiece(new Queen(Board, Color.White), new PositionChess('e', 1).ToPosition());

            //Board.AddPiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());
            //Board.AddPiece(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());

            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('a', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('b', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('f', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('g', 7).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.Black), new PositionChess('h', 7).ToPosition());

            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('a', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('b', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('c', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('d', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('e', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('f', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('g', 2).ToPosition());
            //Board.AddPiece(new Pawn(Board, Color.White), new PositionChess('h', 2).ToPosition());

            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('e', 1).ToPosition());

            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.AddPiece(new Tower(Board, Color.White), new PositionChess('e', 2).ToPosition());

            Board.AddPiece(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());
            Board.AddPiece(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());
        }
    }
}
