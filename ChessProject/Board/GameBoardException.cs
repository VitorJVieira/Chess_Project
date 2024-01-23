using System;

namespace ChessProject.Board {
    internal class GameBoardException : Exception {

        public GameBoardException (string message) : base (message) { }
    }
}
