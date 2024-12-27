using System.Collections.Concurrent;
using TicTacToe.API.Models;

namespace TicTacToe.API.Data
{
    public class InMemoryGameStore
    {
        private ConcurrentDictionary<string, Game> _games = new();

        public ConcurrentDictionary<string, Game> GetGames() => _games;

        public Game CreateGame()
        {
            Game game = new();
            _games[game.Id] = game;
            return game;
        }

        public Game? GetGame(string id) => _games.TryGetValue(id, out var game) ? game : null;

        internal void UpdateGame(string id, Game game) => _games[id] = game;
    }
}