using ChessProject.Board;
using ChessProject.Chess;

namespace ChessProject {
    internal class Program {
        static void Main(string[] args) {
            try {


                GameBoard b = new GameBoard(8, 8);

                b.putPiece(new Tower(Color.Black, b), new Position(0, 0));
                b.putPiece(new Tower(Color.Black, b), new Position(1, 3));
                b.putPiece(new King(Color.Black, b), new Position(0, 2));

                b.putPiece(new Tower(Color.White, b), new Position(4, 3));
                b.putPiece(new Tower(Color.White, b), new Position(6, 2));
                b.putPiece(new King(Color.White, b), new Position(4, 2));

                Screen.printGameboard(b);
            }
            catch (GameBoardException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}