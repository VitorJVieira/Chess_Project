using ChessProject.Board;
using ChessProject.Chess;

namespace ChessProject {
    internal class Program {
        static void Main(string[] args) {
            try {

                ChessMatch match = new ChessMatch();
                
                while (!match.Finished) {
                    Console.Clear();
                    Screen.printGameboard(match.board);

                    Console.WriteLine();
                    Console.Write("From: ");
                    Position from = Screen.readChessPosition().toPosition();
                    Console.Write("To: ");
                    Position to = Screen.readChessPosition().toPosition();

                    match.movePiece(from, to);
                }

                
            }
            catch (GameBoardException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}