using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers
{
    [Route("api/games/{gameName}/boards")]
    public class BoardController : Controller
    {
        private IGameBoardRepository _boardRepository;

        public BoardController(IGameBoardRepository boardRepo)
        {
            _boardRepository = boardRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoards(string gameName)
        {
            var boards = await _boardRepository.GetAllForBoardAsync(gameName);

            if (boards != null)
            {
                return Ok(boards);
            }

            return NotFound();
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetBoard(string gameName, int boardId)
        {
            var board = await _boardRepository.GetByRelativeIdAsync(gameName, boardId);

            if (board != null)
            {
                return Ok(board);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromRoute] string gameName, [FromBody] Board gameBoard)
        {
            if (ModelState.IsValid)
            {
                var createdBoard = await _boardRepository.AddBoardRelativeAsync(gameName, gameBoard);

                if (createdBoard != null)
                {
                    return Ok(createdBoard);
                }

                return StatusCode(500, new
                {
                    Message = "Error encountered creating board!",
                    Data = gameBoard
                });
            }

            var modelErrors = ModelState.Values.SelectMany(v => v.Errors);

            return BadRequest(new
            {
                Message = "Board model not valid!",
                Data = new
                {
                    GameName = gameName,
                    GameBoard = gameBoard
                },
                Errors = modelErrors
            });
        }

        [HttpPut("{boardId}")]
        public async Task<IActionResult> UpdateBoard([FromRoute] string gameName,
                                                     [FromRoute] int boardId,
                                                     [FromBody] Board gameBoard)
        {
            if (ModelState.IsValid)
            {
                if (await _boardRepository.BoardExistsAsync(gameName, boardId))
                {
                    var updatedBoard = await _boardRepository.UpdateBoardAsync(gameName, boardId, gameBoard);

                    if (updatedBoard != null)
                    {
                        return Ok(updatedBoard);
                    }

                    return StatusCode(500, new
                    {
                        Message = "Error encountered creating board!",
                        Data = new
                        {
                            GameName = gameName,
                            BoardId = boardId,
                            GameBoard = gameBoard
                        }
                    });
                }

                return NotFound(new
                {
                    Message = "Specified board does not exist!",
                    Data = new
                    {
                        GameName = gameName,
                        BoardId = boardId,
                        GameBoard = gameBoard
                    }
                });
            }

            var modelErrors = ModelState.Values.SelectMany(v => v.Errors);

            return BadRequest(new
            {
                Message = "Board model not valid!",
                Data = gameBoard,
                Errors = modelErrors
            });
        }

        [HttpDelete("{boardId}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] string gameName,
                                                     [FromRoute] int boardId)
        {
            if (await _boardRepository.BoardExistsAsync(gameName, boardId))
            {
                await _boardRepository.DeleteRelativeAsync(gameName, boardId);
            }

            return NotFound(new
            {
                Message = "Board to delete already does not exist!",
                Data = new
                {
                    GameName = gameName,
                    BoardId = boardId
                }
            });
        }
    }
}