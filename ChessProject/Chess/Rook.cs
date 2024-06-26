﻿using ChessProject.Board;


namespace ChessProject.Chess {
    class Rook : Piece{
        public Rook(Color color, GameBoard board) : base(color, board) {

        }

        public override string ToString() {
            return "T";
        }

        private bool canMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //North
            pos.defineValue(Position.Line - 1 , Position.Column);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.Line--;
            }

            //South
            pos.defineValue(Position.Line + 1, Position.Column);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.Line++;
            }

            //East
            pos.defineValue(Position.Line, Position.Column + 1);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.Column++;
            }

            //West
            pos.defineValue(Position.Line, Position.Column - 1);
            while (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color) {
                    break;
                }
                pos.Column--;
            }


            return mat;
        }
    }
}
