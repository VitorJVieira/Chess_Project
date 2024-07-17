using ChessProject.Board;

namespace ChessProject.Chess {
    class Pawn : Piece {

        private ChessMatch match;

        public Pawn(Color color, GameBoard board, ChessMatch Match) : base(color, board) {
            this.match = Match;
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

                //en passant White side
                if (Position.Line == 3) {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.validPosition(left) && isEnemy(left) && Board.Piece(left) == match.vulnerableEnPassant) {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position rigth = new Position(Position.Line, Position.Column + 1);
                    if (Board.validPosition(rigth) && isEnemy(rigth) && Board.Piece(rigth) == match.vulnerableEnPassant) {
                        mat[rigth.Line - 1, rigth.Column] = true;
                    }
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

                //en passant Black side
                if (Position.Line == 4) {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.validPosition(left) && isEnemy(left) && Board.Piece(left) == match.vulnerableEnPassant) {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position rigth = new Position(Position.Line, Position.Column + 1);
                    if (Board.validPosition(rigth) && isEnemy(rigth) && Board.Piece(rigth) == match.vulnerableEnPassant) {
                        mat[rigth.Line + 1, rigth.Column] = true;
                    }


                }
            }



            return mat;
        }

    }
}
