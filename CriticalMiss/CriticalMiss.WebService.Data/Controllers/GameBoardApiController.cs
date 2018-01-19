using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Data;
using CriticalMiss.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.WebService.Data.Controllers
{
    [Produces("application/json")]
    [Route("api/GameBoardApi")]
    public class GameBoardApiController : Controller
    {
        private static List<Boards> _gameboard = new List<Boards>();

        private CriticalMissDbContext _context;

        public GameBoardApiController(CriticalMissDbContext context)
        {
            _context = context;
        }
       // [HttpGet("{id}", Name = "Get")]
        public IActionResult GetGamesBoard()
        {
            var gameboardlist = _context.Boards.Select(a => a.BoardName);
            return Ok(gameboardlist);
        }

        [HttpGet("{id}", Name = "Get_Board")]
        public IActionResult GetGamesBoard([FromRoute] int id)
        {
            //var gameboardlist = _context.GameBoard.Where(x=>x.GameId==id).Select(x => new {
            //   Name = x.BoardName
            //    });

            //return Ok(gameboardlist);
            var gameBoard = _context.Boards.SingleOrDefault(x => x.BoardId == id);
            return Ok(gameBoard);
        }

        [HttpPost]
        public IActionResult CreateBoardGame([FromBody] Boards gameboard)
        {
            _context.Boards.Add(gameboard);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}", Name = "{BoardName_Update}")]
        public IActionResult UpdateGame([FromRoute] int id, [FromBody] Boards gameboard)
        {

            var upboardgames = _context.Boards.SingleOrDefault(x => x.BoardId == id);
            upboardgames.BoardName = gameboard.BoardName;
            upboardgames.Width = gameboard.Width;
            upboardgames.Height = gameboard.Height;

            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}", Name = "{BoardName_Delete}")]
        public IActionResult DeleteBoard([FromRoute] int Id, Boards gameboard)
        {
            var delgames = _context.Boards.SingleOrDefault(x => x.BoardId == Id);
            _context.Boards.Remove(delgames);
            _context.SaveChanges();
            return Ok();
        }
    }
}