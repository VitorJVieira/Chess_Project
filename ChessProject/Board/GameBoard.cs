
namespace ChessProject.Board {
    internal class GameBoard {

        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public GameBoard(int lines, int columns) {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column) {
            return Pieces[line, column];
        }




    }
}
