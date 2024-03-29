﻿using ChessProject.Board;
using ChessProject.Chess;

namespace ChessProject {
    internal class Screen {

        public static void printMatch(ChessMatch match) {
            printGameboard(match.board);
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            if (!match.Finished) {
                Console.WriteLine("Waiting for play: " + match.TurnPlayer);
                if (match.Check) {
                    Console.WriteLine("CHECK!");
                }
            } else {
                Console.WriteLine("CHECK MATE!!");
                Console.WriteLine("Winner: " + match.TurnPlayer);
            }
        }

        public static void printCapturedPieces(ChessMatch match) {
            ConsoleColor aux = Console.ForegroundColor;
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.Write("Black: ");
            printSet(match.capturedPieces(Color.White));
            
        }

        public static void printSet(HashSet<Piece> set) {
            Console.Write("[");
            foreach (Piece x in set) {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        
        public static void printGameboard(GameBoard board) {
            for (int i = 0; i < board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) {
                    printPiece(board.Piece(i, j));                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static ChessPosition readChessPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void printGameboard(GameBoard board, bool[,] possiblePosition ) {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor otherBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++) {
                    if (possiblePosition[i,j]) { 
                        Console.BackgroundColor = otherBackground;
                    } else {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(board.Piece(i, j));

                }
                Console.WriteLine();
                Console.BackgroundColor = originalBackground;
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece) {

            if (piece == null) {
                Console.Write("- ");
            } else {
                if (piece.Color == Color.White) {
                    Console.Write(piece);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
