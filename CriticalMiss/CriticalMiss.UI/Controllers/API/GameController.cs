using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.API.Controllers
{

    [Route("api/games")]
    public class GameController : Controller
    {
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
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewGame(IFormCollection game)
        {
            return null;
        }

        [HttpPut("{gameName}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditGame(string gameName, IFormCollection gameCollection)
        {
            return null;
        }

        [HttpDelete("{gameName}")]
        public IActionResult DeleteGame(string gameName)
        {
            return null;
        }
    }
}