using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.UI.Controllers
{

    [Route("api/games")]
    public class GameController : Controller
    {
        private IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepository = gameRepo;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            
            return null;
        }

        [HttpGet("{gameName}")]
        public IActionResult GetGame(string gameName)
        {
            return null;
        }

        [HttpPost]
        public IActionResult CreateNewGame([FromBody] Game game)
        {
            return null;
        }

        [HttpPut("{gameName}")]
        public IActionResult EditGame([FromRoute] string gameName, [FromBody] Game game)
        {
            return null;
        }

        [HttpDelete("{gameName}")]
        public IActionResult DeleteGame([FromRoute] string gameName)
        {
            return null;
        }
    }
}