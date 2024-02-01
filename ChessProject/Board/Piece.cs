using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Board {
    abstract class Piece {

        public Position Position { get; set; }

        public Color Color { get; protected set; }
        public int MovesQuant { get; set; } //How many moves the piece already made
        public GameBoard Board { get; set; }

        public Piece(Color color, GameBoard board) {
            Position = null;
            Color = color;
            MovesQuant = 0;
            Board = board;
        }

        public abstract bool[,] possibleMoviments();

        public void addMovesQuant() {
            MovesQuant++;
        }

        public bool havePossibleMoves() {
            bool[,] mat = possibleMoviments();
            for (int i = 0; i<Board.Lines;  i++) {
                for (int j = 0; j < Board.Columns; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos) {
            return possibleMoviments()[pos.Line, pos.Column];
        }

    }
}
