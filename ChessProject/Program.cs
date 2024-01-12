using ChessProject.Board;

namespace ChessProject {
    internal class Program {
        static void Main(string[] args) {
            
            GameBoard b = new GameBoard(8, 8);

            Screen.printGameboard(b);

        }
    }
}