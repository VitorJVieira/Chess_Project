using ChessProject.Board;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace ChessProject.Chess {
    internal class ChessMatch {

        public GameBoard board { get; private set; }
        public int Turn {  get; private set; }
        public Color TurnPlayer {  get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool Check {  get; private set; }



        public ChessMatch() {
            board = new GameBoard(8, 8);
            Turn = 1;
            TurnPlayer = Color.White;
            Check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPieces();
        }

        public Piece movePiece(Position from, Position to) {
            Piece p = board.removePiece(from);
            p.addMovesQuant();
            Piece deadPiece = board.removePiece(to);
            Finished = false;
            board.putPiece(p, to);
            if (deadPiece != null) {
                captured.Add(deadPiece);
            }
            return deadPiece;
        }

        public void undoMovement(Position from, Position to, Piece deadPiece) {
            Piece p = board.removePiece(to);
            p.removeMovesQuant();
            if (deadPiece != null) {
                board.putPiece(deadPiece, to);
                captured.Remove(deadPiece);
            }
            board.putPiece(p, from);
        }

        public void makePlay(Position from, Position to) {
            Piece deadPiece = movePiece(from, to);
            
            if (isCheck(TurnPlayer)) {
                undoMovement(from, to, deadPiece);
                throw new GameBoardException("You can't put yourself in check!");
            }

            if (isCheck(opponent(TurnPlayer))) {
                Check = true;

            } else {
                Check = false;
            }

            if (isCheckMate(opponent(TurnPlayer))) {
                Finished = true;
            } else {
                Turn++;
                changePlayer();
            }

            
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

        private Color opponent(Color color) {
            if (color == Color.White) {
                return Color.Black;
            } else { 
                return Color.White;
            }
        }

        private Piece king(Color color) {
            foreach (Piece x in inGamePieces(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null;
        }

        public bool isCheck(Color color) {
            Piece r = king(color);
            foreach (Piece x in inGamePieces(opponent(color))) {
                bool[,] mat = x.possibleMoviments();
                if (mat[r.Position.Line, r.Position.Column]) {
                    return true;
                }
            }
            return false;
        }

        public bool isCheckMate(Color color) {
            if (!isCheck(color)) {
                return false;
            }
            foreach (Piece x in inGamePieces(color)) {
                bool[,] mat = x.possibleMoviments();
                for (int i = 0; i < board.Lines; i++) {
                    for (int j = 0; j < board.Columns; j++) { 
                        if (mat[i,j]) {
                            Position from = x.Position;
                            Position to = new Position(i, j);
                            Piece piece = movePiece(from, to);
                            bool testCheck = isCheck(color);
                            undoMovement(from,to, piece);
                            if (!testCheck) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void insertNewPiece(char column, int line, Piece piece) {
            board.putPiece(piece, new ChessPosition(column,line).toPosition());
            pieces.Add(piece);
        }

        private void insertPieces() {
            insertNewPiece('c', 1, new Tower(Color.White, board));
            insertNewPiece('h', 7, new Tower(Color.White, board));
            insertNewPiece('d', 1, new King(Color.White, board));

            insertNewPiece('b', 8, new Tower(Color.Black, board));
            insertNewPiece('a', 8, new King(Color.Black, board));
        }


    }
}
