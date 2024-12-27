namespace TicTacToe.API.Models
{
    public class Game
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public char[,] Board { get; set; } = new char[3, 3];
        public string CurrentPlayer { get; set; } = "X";
        public string Winner { get; set; }
        public bool IsDraw { get; set; }
    }
}