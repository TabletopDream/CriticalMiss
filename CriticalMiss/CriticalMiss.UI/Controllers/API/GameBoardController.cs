using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers.API
{
    [Route("api/games/{gameName}/boards")]
    public class GameBoardController : Controller
    {
        [HttpGet]
        public IActionResult GetAllBoards()
        {
            return null;
        }

        [HttpGet("{id}")]
        public IActionResult GetGameBoard(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult CreateNewBoard(IFormCollection board)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult EditBoard(int id, object obj)
        {
            return null;
        }
    }
}