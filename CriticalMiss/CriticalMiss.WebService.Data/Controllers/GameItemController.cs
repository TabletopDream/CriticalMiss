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
    [Route("api/GameItem")]
    public class GameItemController : Controller
    {
        private static List<Item> _gameitem = new List<Item>();

        private CriticalMissDbContext _context;

        public GameItemController(CriticalMissDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetGamesBoard()
        {
            var gameboardlist = _context.GameBoard.Select(a => a.BoardName);
            return Ok(gameboardlist);
        }

        [HttpGet("{id}")]
        public IActionResult GetGamesItem([FromRoute] int id)
        {
            var gameboardlist = _context.item.Where(x => x.ItemId == id).Select(x => new
            {
                Name = x.Name
            });
            return Ok(gameboardlist);
        }

        [HttpPost]
        public IActionResult CreateBoardGame([FromBody] Item gameitem)
        {
            _context.item.Add(gameitem);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}", Name ="{ItemName_Update}")]
        public IActionResult UpdateGame([FromRoute] int id, [FromBody]Item gameitem)
        {

            var upboardgames = _context.item.SingleOrDefault(x => x.ItemId==id);
            upboardgames.Name = gameitem.Name;   
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete("{id}", Name = "{ItemName_Delete}")]
        public IActionResult DeleteBoard([FromRoute] int Id, Boards gameboard)
        {
            var delgames = _context.item.SingleOrDefault(x => x.ItemId== Id);
            _context.item.Remove(delgames);
            _context.SaveChanges();
            return Ok();
        }
    }
}