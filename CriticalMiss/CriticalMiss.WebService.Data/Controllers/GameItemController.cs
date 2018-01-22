using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Data;
using CriticalMiss.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public IActionResult GetGamesItem()
        {
            var gameboardlist = _context.item.ToList();
            if (gameboardlist != null)
            {
                return Ok(gameboardlist);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetGamesItem([FromRoute] int id)
        {
            var gameboardlist = _context.item.Include(i => i.ImageAssetNavigable)
                                             .Where(x => x.ItemId == id);
            if (gameboardlist!=null)
            {
                return Ok(gameboardlist);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateBoardGame([FromBody] Item gameitem)
        {
            _context.item.Add(gameitem);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}", Name = "{ItemName_Update}")]
        public IActionResult UpdateGame([FromRoute] int id, [FromBody]Item gameitem)
        {

            var upboardgames = _context.item.SingleOrDefault(x => x.ItemId == id);
            if (upboardgames != null)
            {
                upboardgames.Name = gameitem.Name;

                _context.Update(upboardgames);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete("{id}", Name = "{ItemName_Delete}")]
        public IActionResult DeleteBoard([FromRoute] int Id, Boards gameboard)
        {
            var delgames = _context.item.SingleOrDefault(x => x.ItemId == Id);
            if (delgames!=null)
            {
                _context.item.Remove(delgames);
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