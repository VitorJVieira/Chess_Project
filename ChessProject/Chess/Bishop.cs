using ChessProject.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Chess {
    internal class Bishop : Piece {

        public Bishop(Color color, GameBoard board) : base(color, board) {

        }

        public override string ToString() {
            return "B";
        }

        private bool canMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);


            //NW
            pos.defineValue(Position.Line - 1, Position.Column - 1);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.defineValue(pos.Line - 1, pos.Column - 1);
            }

            //NE
            pos.defineValue(Position.Line - 1, Position.Column + 1 );
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.defineValue(pos.Line - 1, pos.Column + 1);
            }

            //SW
            pos.defineValue(Position.Line + 1, Position.Column - 1);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.defineValue(pos.Line + 1, pos.Column - 1);
            }

            //SE
            pos.defineValue(Position.Line + 1, Position.Column + 1);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.defineValue(pos.Line + 1, pos.Column + 1);
            }

            return mat;
        }

    }
}
