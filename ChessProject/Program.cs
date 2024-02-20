using ChessProject.Board;
using ChessProject.Chess;

namespace ChessProject {
    internal class Program {
        static void Main(string[] args) {
            try {

                ChessMatch match = new ChessMatch();
                
                while (!match.Finished) {
                    try {

                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("From: ");
                        Position from = Screen.readChessPosition().toPosition();
                        match.validFrom(from);

                        bool[,] possiblePosition = match.board.Piece(from).possibleMoviments();

                        Console.Clear();
                        Screen.printGameboard(match.board, possiblePosition);

                        Console.WriteLine();
                        Console.Write("To: ");
                        Position to = Screen.readChessPosition().toPosition();
                        match.validTo(from, to);

                        match.makePlay(from, to);
                    } catch (GameBoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.printMatch(match);
                
            }
            catch (GameBoardException e) {
                Console.WriteLine(e.Message);
            }

        }
    }
}