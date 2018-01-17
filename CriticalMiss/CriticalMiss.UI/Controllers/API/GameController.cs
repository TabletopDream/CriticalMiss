using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.UI.API.Controllers
{

    [Route("api/games")]
    public class GameController : Controller
    {
        //private IGameRepository _gamerepository;

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

        [HttpPut]
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