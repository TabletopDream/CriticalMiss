using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CriticalMiss.WebService.Data.Models;
using CriticalMiss.Library.Models;
using CriticalMiss.Data;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using CriticalMiss.Data.Models;

namespace CriticalMiss.WebService.Data.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {

        private static List<TabletopGame> _games = new List<TabletopGame>();

        private CriticalMissDbContext _context;

        public GameController(CriticalMissDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IEnumerable Get()
        //{
        //    var getgames= _context.games.AsEnumerable();
        //    return getgames;
        //}

        //[HttpGet]
        //[HttpGet("Id}", Name = "Get")]
        //public IActionResult Get(int Id)
        //{
        //    var getgamesid = _context.games.Select(m => m.GameId == Id).AsEnumerable();
        //    return OK(getgamesid);
        //}

        [HttpGet("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {

            Games getgamesid = _context.games.Find(id);

            return Ok(getgamesid);
        }
    }
}