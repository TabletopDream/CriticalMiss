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
        [HttpGet]
        public IActionResult GetGamesBoard([FromQuery]string gameName)
        {
            //var gameboardlist = _context.Boards.Select(a => a.BoardName);
            var gameboardlist = _context.Boards.ToList();
            List<Boards> boards = new List<Boards>();
            for(int i = 0; i < gameboardlist.Count; i++)
            {
                if (gameboardlist[i].GameName == gameName)
                {
                    boards.Add(gameboardlist[i]);
                }
            }
            if (gameboardlist != null)
            {
                return Ok(boards);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("boardId")]
        public IActionResult GetGamesBoard([FromRoute] int boardId, [FromQuery]string gameName)
        {
            //var gameboardlist = _context.GameBoard.Where(x=>x.GameId==id).Select(x => new {
            //   Name = x.BoardName
            //    });

            //return Ok(gameboardlist);

            var gameBoard = _context.Boards.SingleOrDefault(x => x.BoardId == boardId && x.GameName == gameName);
            
            if (gameBoard != null)
            {
                return Ok(gameBoard);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateBoardGame([FromBody] Boards gameboard)
        {
            _context.Boards.Add(gameboard);
            _context.SaveChanges();
            return Ok(gameboard);
        }

        [HttpPut("{id}", Name = "{BoardName_Update}")]
        public IActionResult UpdateGame([FromRoute] int id, [FromBody] Boards gameboard)
        {

            var upboardgames = _context.Boards.SingleOrDefault(x => x.BoardId == id && x.GameName == gameboard.GameName);
            if (upboardgames != null)
            {
                upboardgames.BoardName = gameboard.BoardName;
                upboardgames.Width = gameboard.Width;
                upboardgames.Height = gameboard.Height;

                _context.Update(upboardgames);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete("{id}", Name = "{BoardName_Delete}")]
        public IActionResult DeleteBoard([FromRoute] int Id, [FromQuery]string gameName)
        {
            var delgames = _context.Boards.SingleOrDefault(x => x.BoardId == Id && x.GameName == gameName);
            if (delgames != null)
            {
                _context.Boards.Remove(delgames);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}