using ChessProject.Board;
using System.Collections.Generic;

namespace ChessProject.Chess {
    internal class ChessMatch {

        public GameBoard board { get; private set; }
        public int Turn {  get; private set; }
        public Color TurnPlayer {  get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;



        public ChessMatch() {
            board = new GameBoard(8, 8);
            Turn = 1;
            TurnPlayer = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();
        }

        public void movePiece(Position from, Position to) {
            Piece p = board.removePiece(from);
            p.addMovesQuant();
            Piece deadPiece = board.removePiece(to);
            Finished = false;
            board.putPiece(p, to);
            if (deadPiece != null) {
                captured.Add(deadPiece);
            }
        }

        public void makePlay(Position from, Position to) {
            movePiece(from, to);
            Turn++;
            changePlayer();
        }

        public void validFrom(Position pos) {
            if (board.Piece(pos) == null) {
                throw new GameBoardException("There is no piece in this position.");
            }
            if (TurnPlayer != board.Piece(pos).Color) {
                throw new GameBoardException("The piece don't have the same color as you.");
            }
            if (!board.Piece(pos).havePossibleMoves()) {
                throw new GameBoardException("There is no possible movements for this piece.");
            }
        }

        public void validTo(Position from, Position to) {
            if (!board.Piece(from).canMoveTo(to)) {
                throw new GameBoardException("Invalid destination position");
            }
        }

        public void changePlayer() {
            if (TurnPlayer == Color.White) {
                TurnPlayer = Color.Black;
            } else {
                TurnPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if (x.Color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> inGamePieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces) {
                if (x.Color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void insertNewPiece(char column, int line, Piece piece) {
            board.putPiece(piece, new ChessPosition(column,line).toPosition());
            pieces.Add(piece);
        }

        private void insertPieces() {
            insertNewPiece('c', 8, new Tower(Color.Black, board));



            insertNewPiece('c', 7, new Tower(Color.Black, board));
            insertNewPiece('d', 7, new Tower(Color.Black, board));
            insertNewPiece('e', 7, new Tower(Color.Black, board));
            insertNewPiece('e', 8, new Tower(Color.Black, board));
            insertNewPiece('d', 8, new King(Color.Black, board));

            insertNewPiece('c', 1, new Tower(Color.White, board));
            insertNewPiece('c', 2, new Tower(Color.White, board));
            insertNewPiece('d', 2, new Tower(Color.White, board));
            insertNewPiece('e', 2, new Tower(Color.White, board));
            insertNewPiece('e', 1, new Tower(Color.White, board));
            insertNewPiece('d', 1, new King(Color.White, board));
        }


    }
}
