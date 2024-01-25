using ChessProject.Board;

namespace ChessProject.Chess {
    internal class King : Piece {

        public King(Color color, GameBoard board) : base(color, board) {

        }

        public override string ToString() {
            return "R";
        }

        private bool canMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color; 
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //North
            pos.defineValue(Position.Line - 1, Position.Column);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //NorthEast
            pos.defineValue(Position.Line - 1, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //East
            pos.defineValue(Position.Line, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //SouthEast
            pos.defineValue(Position.Line + 1, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //South
            pos.defineValue(Position.Line + 1, Position.Column);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //SoutWest
            pos.defineValue(Position.Line + 1, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //West
            pos.defineValue(Position.Line, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //NorthWest
            pos.defineValue(Position.Line - 1, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
