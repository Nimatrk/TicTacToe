using TicTacToe.API.Models;

namespace TicTacToe.API.Services
{
    public class GameService
    {
        public bool MakeMove(Game game, Move move)
        {
            // validate input
            if (move.Row < 0 || move.Row > 2 || move.Column < 0 || move.Column > 2 ||
                game.Board[move.Row, move.Column] != default ||
                game.Winner != null)
                return false;
            // applying the move
            game.Board[move.Row, move.Column] = move.Player[0];
            // check game state for winner or tie
            if (CheckWinner(game.Board, move.Player[0]))
                game.Winner = move.Player;
            else if (IsBoardFull(game.Board))
                game.IsDraw = true;
            else
                game.CurrentPlayer = game.CurrentPlayer == "X" ? "O" : "X";
            return true;

        }

        private bool IsBoardFull(char[,] board)
        {
            foreach (var cell in board)
                if (cell == default) return false;
            return true;
        }

        private bool CheckWinner(char[,] board, char player)
        {
            // horizontal and vertical check
            for (var i = 0; i < 3; i++)
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player ||
                    board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            // oblique check
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player ||
                board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;
            return false;
        }
    }
}