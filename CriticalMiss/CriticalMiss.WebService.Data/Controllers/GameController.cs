using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CriticalMiss.WebService.Data.Models;
using CriticalMiss.Data;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using CriticalMiss.Data.Models;
using CriticalMiss.Common.Interfaces;

namespace CriticalMiss.WebService.Data.Controllers
{
    [Produces("application/json")]
    [Route("api/games")]
    public class GameController : Controller
    {

        private static List<Games> _games = new List<Games>();

        private CriticalMissDbContext _context;

        public GameController(CriticalMissDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {

            var getgames = _context.games.ToList();
            if (getgames!=null)
            {
                return Ok(getgames);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //[HttpGet("Id}", Name = "Get")]
        //public IActionResult Get(int Id)
        //{
        //    var getgamesid = _context.games.Select(m => m.GameId == Id).AsEnumerable();
        //    return OK(getgamesid);
        //}

        [HttpGet("{id}")]
        public IActionResult GetGames([FromRoute] int id)
        {
            //var getgamesbyid = _context.games.Where(a => a.GameId == id).Select(a => new {
            //    Name = a.GameName,
            //});
            //return Ok(getgamesbyid);

            var gamesList = _context.games.Where(a => a.GameId == id);
            if (gamesList!=null)
            {
                return Ok(gamesList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] Games game)
        {
            var creategames=_context.games.Add(game);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}", Name = "{GameName_Delete}")]
        public IActionResult DeleteGame([FromRoute] int id, Games game)
        {
            var delgames = _context.games.SingleOrDefault(x => x.GameId == id);
            if (delgames!=null)
            {
                _context.games.Remove(delgames);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id}", Name = "{GameName_Update}")]
        public IActionResult UpdateGame([FromRoute] int id, [FromBody] Games game)
        {

            var upgames = _context.games.SingleOrDefault(x => x.GameId == id);
            if (upgames == null)
            {
                upgames.GameName = game.GameName;
                _context.Update(upgames);
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