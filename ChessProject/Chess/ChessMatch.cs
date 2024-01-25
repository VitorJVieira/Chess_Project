using ChessProject.Board;

namespace ChessProject.Chess {
    internal class ChessMatch {

        public GameBoard board { get; private set; }  
        private int Turn;
        private Color TurnPlayer;
        public bool Finished {  get; private set; }

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

        private void insertPieces() {
            board.putPiece(new Tower(Color.Black, board), new ChessPosition('c',8).toPosition());
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
