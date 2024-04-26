using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Chess {
    class Knight : Piece {

        public Knight(Color color, GameBoard board) : base(color, board) {

        }

        public override string ToString() {
            return "N"; //it will be used the N as the algebric notation, to not confused with the "K", symbol of King
        }

        private bool canMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);


            
            pos.defineValue(Position.Line - 1, Position.Column - 2);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line - 2, Position.Column - 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line - 2, Position.Column + 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line - 1, Position.Column + 2);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line + 1, Position.Column + 2);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line + 2, Position.Column + 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line + 1, Position.Column - 2);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            pos.defineValue(Position.Line + 2, Position.Column - 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }


            return mat;
        }
    }
}
