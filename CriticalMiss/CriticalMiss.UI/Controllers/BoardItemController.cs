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
    [Produces("application/json")]
    [Route("api/games/{gameName}/boards/{boardId:int}/items")]
    public class BoardItemController : Controller
    {
        private IGameItemRepository _itemRepository;

        public BoardItemController(IGameItemRepository itemRepo)
        {
            _itemRepository = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems([FromRoute] string gameName, [FromRoute] int boardId)
        {
            try
            {
                var items = await _itemRepository.GetAllAsync(gameName, boardId);

                return Ok(items);
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Game/Board does not exist!",
                    Exception = ex.Message
                });
            }
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetItem([FromRoute] string gameName,
                                                 [FromRoute] int boardId,
                                                 [FromRoute] int itemId)
        {
            try
            {
                var game = await _itemRepository.GetAsync(gameName, boardId, itemId);

                return Ok(game);
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Item not found!",
                    Exception = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromRoute] string gameName,
                                                    [FromRoute] int boardId,
                                                    [FromBody] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdGame = await _itemRepository.AddAsync(item, gameName, boardId);

                    return Ok(createdGame);
                }

                return BadRequest(new
                {
                    Message = "Item model not valid!",
                    Data = new
                    {
                        Body = item,
                        Request.Path
                    },
                    Errors = ModelState.Values
                });
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Game/Board not found!",
                    Exception = ex.Message
                });
            }
        }

        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItem([FromRoute] string gameName,
                                                    [FromRoute] int boardId,
                                                    [FromRoute] int itemId,
                                                    [FromBody] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedItem = await _itemRepository.UpdateAsync(item, gameName, boardId, itemId);

                    return Ok(updatedItem);
                }

                return BadRequest(new
                {
                    Message = "Item model change not valid!",
                    Data = new
                    {
                        Body = item,
                        Request.Path
                    },
                    Errors = ModelState.Values
                });
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Item not found!",
                    Exception = ex.Message
                });
            }
        }

        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItem([FromRoute] string gameName,
                                                    [FromRoute] int boardId,
                                                    [FromRoute] int itemId)
        {
            try
            {
                await _itemRepository.DeleteAsync(gameName, boardId, itemId);

                return Ok();
            }
            catch (HttpResourceNotFoundException ex)
            {
                return NotFound(new
                {
                    Message = "Item not found!",
                    Exception = ex.Message
                });
            }
        }
    }
}