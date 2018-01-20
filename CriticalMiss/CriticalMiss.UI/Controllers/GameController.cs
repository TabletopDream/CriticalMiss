using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CriticalMiss.UI.Exceptions;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.UI.Controllers
{

    [Route("api/games")]
    public class GameController : Controller
    {
        private IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepo)
        {
            _gameRepository = gameRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameRepository.GetAllAsync();
            foreach (var game in games)
            {
                game.Password = null;
            }
            return Ok(games);
        }

        [HttpGet("{gameName}")]
        public async Task<IActionResult> GetGame([FromRoute] string gameName)
        {
            try
            {
                var game = await _gameRepository.GetAsync(gameName);
                game.Password = null;
                return Ok(game);
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Game not found!",
                    Exception = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGame([FromBody] Game game)
        {
            if (ModelState.IsValid)
            {
                var newGame = await _gameRepository.AddAsync(game);
                newGame.Password = null;
                return Ok(newGame);
            }

            return BadRequest(new
            {
                Message = "Game POST request validation failure!",
                Data = new
                {
                    body = game,
                    path = Request.Path
                },
                Errors = ModelState.Values
            });
        }

        [HttpPut("{gameName}")]
        public async Task<IActionResult> EditGame([FromRoute] string gameName, [FromBody] Game game)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var updatedGame = await _gameRepository.UpdateAsync(game, gameName);
                    updatedGame.Password = null;
                    return Ok(updatedGame);
                }
                catch (HttpResourceNotFoundException ex)
                {
                    return NotFound(new
                    {
                        Message = "Game not found!",
                        Exception = ex.Message
                    });
                }
            }

            return BadRequest(new
            {
                Message = "Game PUT request validation failure!",
                Data = new
                {
                    Body = game,
                    Request.Path
                },
                Errors = ModelState.Values
            });
        }

        [HttpDelete("{gameName}")]
        public async Task<IActionResult> DeleteGame([FromRoute] string gameName)
        {
            try
            {
                await _gameRepository.DeleteAsync(gameName);

                return Ok();
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Game not found!",
                    Exception = ex.Message
                });
            }
        }
    }
}