using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.API.Controllers
{

    public class GameController : Controller
    {
        [HttpGet("/games", Name ="All_Games")]
        public IActionResult GetAllGames()
        {
            return null;
        }

        [HttpGet("/games/{name}/")]
        public IActionResult GetGame(string name)
        {
            return null;
        }

        [HttpPost("/games")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewGame(IFormCollection game)
        {
            return null;
        }

        [HttpPut("/games/{name}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditGame(string name, IFormCollection gameCollection)
        {
            return null;
        }

        [HttpDelete("/games/{name}")]
        public IActionResult DeleteGame(string name)
        {
            return null;
        }
    }
}