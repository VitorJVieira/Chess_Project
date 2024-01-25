

namespace ChessProject.Board {
    internal class GameBoard {

        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public GameBoard(int lines, int columns) {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column) {
            return Pieces[line, column];
        }

        public Piece Piece(Position pos) {
            return Pieces[pos.Line, pos.Column];
        }


        public bool havePiece(Position pos) {
            validPosition(pos);
            return Piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos) {
            if (havePiece(pos)) {
                throw new GameBoardException("Já existe uma peça nessa posição!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece removePiece(Position pos) {
            if (Piece(pos) == null) {
                return null;
            }
            Piece aux = Piece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool positionCheck(Position pos) {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns) {
                return false;
            }
            return true;        
        }

        public void validPosition(Position pos) {
            if (!positionCheck(pos)) {
                throw new GameBoardException("Posição inválida!");
            }
        }

        
    }
}
