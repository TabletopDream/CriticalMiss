using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CriticalMiss.WebService.Data.Models;
using CriticalMiss.Library.Models;
using System.Collections;

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

        [HttpGet]
        public IEnumerable Get()
        {
            return _context.tabletopgames;
            //return Ok(_games);
        }

        [HttpGet]
        public IActionResult Get(int Id)
        {
            //var getgames = _games.Select(g => g.GameId == Id).ToList();
            //return View(getgames);
        }
    }
}