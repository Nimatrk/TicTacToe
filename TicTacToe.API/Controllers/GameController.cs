using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicTacToe.API.Data;
using TicTacToe.API.Models;
using TicTacToe.API.Services;

namespace TicTacToe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly InMemoryGameStore _gameStore;
        private readonly GameService _gameService;

        public GameController(InMemoryGameStore gameStore, GameService gameService)
        {
            _gameStore = gameStore;
            _gameService = gameService;
        }

        [HttpGet("all")]
        public IActionResult GetAllGames()
        {
            var games = _gameStore.GetGames();
            return Ok(JsonConvert.SerializeObject(games));
        }

        [HttpPost("create")]
        public IActionResult CreateGame()
        {
            var game = _gameStore.CreateGame();
            return Ok(JsonConvert.SerializeObject(game));
        }

        [HttpPost("{id}/move")]
        public IActionResult MakeMove(string id, Move move)
        {
            var game = _gameStore.GetGame(id);
            if(game == null) return NotFound("Game not found.");
            if (!_gameService.MakeMove(game, move)) return BadRequest("Invalid move.");
            _gameStore.UpdateGame(id, game);
            return Ok(JsonConvert.SerializeObject(game));
        }
    }
}