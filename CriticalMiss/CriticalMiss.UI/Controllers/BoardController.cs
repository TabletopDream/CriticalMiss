using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.UI.Exceptions;
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
        private IGameItemRepository _itemRepository;

        public BoardController(IGameBoardRepository boardRepo,
                               IGameItemRepository itemRepo)
        {
            _boardRepository = boardRepo;
            _itemRepository = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBoards(string gameName)
        {

            try
            {
                var boards = await _boardRepository.GetAllAsync(gameName);

                return Ok(boards);
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Game name does not exist!",
                    Exception = ex.Message
                });
            }
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetBoard(string gameName, int boardId)
        {
            try
            {
                var boardRequest = _boardRepository.GetAsync(gameName, boardId);
                var itemsRequest = _itemRepository.GetAllAsync(gameName, boardId);

                return Ok(new BoardCollectionModel()
                {
                    Board = await boardRequest,
                    BoardItems = await itemsRequest
                });
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Game/board not found!",
                    Exception = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromRoute] string gameName, [FromBody] Board gameBoard)
        {
            if (ModelState.IsValid)
            {
                var createdBoard = await _boardRepository.AddAsync(gameBoard, gameName);

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
                    Body = gameBoard,
                    Request.Path
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
                var updatedBoard = await _boardRepository.UpdateAsync(gameBoard, gameName, boardId);

                if (updatedBoard != null)
                {
                    return Ok(updatedBoard);
                }

                return StatusCode(500, new
                {
                    Message = "Error encountered creating board!",
                    Data = new
                    {
                        Body = gameBoard,
                        Request.Path
                    }
                });
            }

            var modelErrors = ModelState.Values.SelectMany(v => v.Errors);

            return BadRequest(new
            {
                Message = "Board model not valid!",
                Data = new
                {
                    Body = gameBoard,
                    Request.Path
                },
                Errors = modelErrors
            });
        }

        [HttpDelete("{boardId}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] string gameName,
                                                     [FromRoute] int boardId)
        {
            await _boardRepository.DeleteAsync(gameName, boardId);

            return NotFound(new
            {
                Message = "Board to delete already does not exist!",
                Data = new
                {
                    Request.Path
                }
            });
        }
    }
}