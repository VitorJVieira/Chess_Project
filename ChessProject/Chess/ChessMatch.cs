using ChessProject.Board;

namespace ChessProject.Chess {
    internal class ChessMatch {

        public GameBoard board { get; private set; }
        public int Turn {  get; private set; }
        public Color TurnPlayer {  get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch() {
            board = new GameBoard(8, 8);
            Turn = 1;
            TurnPlayer = Color.White;
            insertPieces();
        }

        public void movePiece(Position from, Position to) {
            Piece p = board.removePiece(from);
            p.addMovesQuant();
            Piece deadPiece = board.removePiece(to);
            Finished = false;
            board.putPiece(p, to);
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

        private void insertPieces() {
            board.putPiece(new Tower(Color.Black, board), new ChessPosition('c', 8).toPosition());
            board.putPiece(new Tower(Color.Black, board), new ChessPosition('c', 7).toPosition());
            board.putPiece(new Tower(Color.Black, board), new ChessPosition('d', 7).toPosition());
            board.putPiece(new Tower(Color.Black, board), new ChessPosition('e', 7).toPosition());
            board.putPiece(new Tower(Color.Black, board), new ChessPosition('e', 8).toPosition());
            board.putPiece(new King(Color.Black, board), new ChessPosition('d', 8).toPosition());

            board.putPiece(new Tower(Color.White, board), new ChessPosition('c', 1).toPosition());
            board.putPiece(new Tower(Color.White, board), new ChessPosition('c', 2).toPosition());
            board.putPiece(new Tower(Color.White, board), new ChessPosition('d', 2).toPosition());
            board.putPiece(new Tower(Color.White, board), new ChessPosition('e', 2).toPosition());
            board.putPiece(new Tower(Color.White, board), new ChessPosition('e', 1).toPosition());
            board.putPiece(new King(Color.White, board), new ChessPosition('d', 1).toPosition());
        }


    }
}
