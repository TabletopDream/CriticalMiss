﻿using System;
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
        public IEnumerable GetAllGames()
        {
            var getgames = _context.games.AsEnumerable();
            return getgames;
        }

        //[HttpGet]
        //[HttpGet("Id}", Name = "Get")]
        //public IActionResult Get(int Id)
        //{
        //    var getgamesid = _context.games.Select(m => m.GameId == Id).AsEnumerable();
        //    return OK(getgamesid);
        //}

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetGames([FromRoute] int id)
        {
            //var getgamesbyid = _context.games.Where(a => a.GameId == id).Select(a => new {
            //    Name = a.GameName,

            //});
            //return Ok(getgamesbyid);

            var gamesList = _context.games.Where(a => a.GameId == id);
            return Ok(gamesList);
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] Games game)
        {
            _context.games.Add(game);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{GameName}")]
        public IActionResult DeleteGame([FromRoute] string GameName, Games game)
        {
            var delgames = _context.games.SingleOrDefault(x => x.GameId == game.GameId);
            _context.games.Remove(delgames);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{GameName}")]
        public IActionResult UpdateGame([FromRoute] string GameName, [FromBody] Games game)
        {

            var upgames = _context.games.SingleOrDefault(x => x.GameId == game.GameId);
            upgames.GameId = game.GameId;
            upgames.GameName = game.GameName;

            _context.SaveChanges();

            return Ok();
        }
    }
}