using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Data;
using CriticalMiss.Library.Repository.Interfaces;
using CriticalMiss.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers.API
{
    [Route("api/boards")]
    public class GameBoardController : Controller
    {
        private CriticalMissDbContext _context;

        private IGameBoardRepository _gameBoardRepo;

        public GameBoardController(CriticalMissDbContext context,
                                   IGameBoardRepository boardRepo)
        {
            _context = context;
            _gameBoardRepo = boardRepo;
        }

        // This functionality needs to be moved into the Games controller, as that
        // is the appropriate place for this request/return
        [HttpGet("api/games/{gameId:int}/boards")]
        //[Produces("application/json")]
        //public IActionResult GetAllBoardsForGame([FromRoute] int gameId)
        //{
        //    try
        //    {
        //        var boards = _gameBoardRepo.GetBoardsForGame(gameId);

        //        var returnObject = new { gameid = gameId, boards };
        //        return Ok(returnObject);
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // The InvalidOperationException is thrown by the repo when
        //        // the submitted game ID does not exist within the database.

        //        return NotFound(new { message = ex.Message});
        //    }
        //}

        [HttpGet("api/boards/{id:int}")]
        public IActionResult GetGameBoard([FromRoute] int id)
        {
            try
            {
                var gameBoard = _gameBoardRepo.GetById(id);

                return Ok(gameBoard);
            }
            catch (InvalidOperationException ex)
            {
                // No game board with that unique ID
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("api/boards")]
        public IActionResult CreateNewBoard([FromBody] NewBoardJsonViewModel models)
        {
            return null;
        }

        [HttpPut("api/boards")]
        public IActionResult EditBoard([FromBody] int gameId, object obj)
        {
            return null;
        }
    }
}