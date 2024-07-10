using ChessProject.Board;

namespace ChessProject.Chess {
    class King : Piece {

        private ChessMatch match;

        public King(Color color, GameBoard board, ChessMatch match) : base(color, board) {
            this.match = match;
        }

        public override string ToString() {
            return "R";
        }

        private bool canMove(Position pos) {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color; 
        }

        private bool canCastling(Position pos) {
            Piece p = Board.Piece(pos);
            return p != null && p is Rook && p.Color == Color && p.MovesQuant ==0;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //North
            pos.defineValue(Position.Line - 1, Position.Column);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //NorthEast
            pos.defineValue(Position.Line - 1, Position.Column + 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //East
            pos.defineValue(Position.Line, Position.Column + 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //SouthEast
            pos.defineValue(Position.Line + 1, Position.Column + 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //South
            pos.defineValue(Position.Line + 1, Position.Column);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //SoutWest
            pos.defineValue(Position.Line + 1, Position.Column - 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //West
            pos.defineValue(Position.Line, Position.Column - 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }

            //NorthWest
            pos.defineValue(Position.Line - 1, Position.Column - 1);
            if (Board.positionCheck(pos) && canMove(pos)) {
                mat[pos.Line, pos.Column] = true;
            }


            //Castling
            if (MovesQuant == 0 && !match.Check) {
                //kingside 
                Position pos1 = new Position(Position.Line, Position.Column + 3);
                if (canCastling(pos1)) {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null) {
                        mat[Position.Line, Position.Column + 2] = true;
                    }

                } 
                //Queenside 
                Position pos2 = new Position(Position.Line, Position.Column - 4);
                if (canCastling(pos2)) {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null) {
                        mat[Position.Line, Position.Column - 2] = true;
                    }

                }

            }


            return mat;
        }
    }
}
