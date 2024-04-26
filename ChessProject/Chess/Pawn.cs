using ChessProject.Board;

namespace ChessProject.Chess {
    class Pawn : Piece {
        public Pawn(Color color, GameBoard board) : base(color, board) {

        }

        public override string ToString() {
            return "P";
        }

        private bool isEnemy(Position pos) {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != Color;
        }

        private bool free(Position pos) {
            return Board.Piece(pos) == null;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White) {
                
                pos.defineValue(Position.Line - 1, Position.Column);
                if (Board.positionCheck(pos) && free(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValue(Position.Line - 2, Position.Column);
                if (Board.positionCheck(pos) && free(pos) && MovesQuant == 0) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValue(Position.Line - 1, Position.Column - 1);
                if (Board.positionCheck(pos) && isEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValue(Position.Line - 1, Position.Column + 1);
                if (Board.positionCheck(pos) && isEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

            } else {
                pos.defineValue(Position.Line + 1, Position.Column);
                if (Board.positionCheck(pos) && free(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValue(Position.Line + 2, Position.Column);
                if (Board.positionCheck(pos) && free(pos) && MovesQuant == 0) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValue(Position.Line + 1, Position.Column - 1);
                if (Board.positionCheck(pos) && isEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.defineValue(Position.Line + 1, Position.Column + 1);
                if (Board.positionCheck(pos) && isEnemy(pos)) {
                    mat[pos.Line, pos.Column] = true;
                }
            }

            return mat;
        }

    }
}
