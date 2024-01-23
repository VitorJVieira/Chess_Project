using ChessProject.Board;


namespace ChessProject.Chess {
    internal class Tower : Piece{
        public Tower(Color color, GameBoard board) : base(color, board) {

        }

        public override string ToString() {
            return "T";
        }
    }
}
