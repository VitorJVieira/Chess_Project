using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject {
    internal class Screen {

        public static void printGameboard(GameBoard board) {
            for (int i = 0; i < board.Lines; i++) {
                for (int j = 0; j < board.Columns; j++) {
                    if (board.Piece(i, j) == null) {
                        Console.Write("- ");
                    } else {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
