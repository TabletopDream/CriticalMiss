using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers.API
{
    public class BoardRestConsumeController : Controller
    {
        private IGameBoardRepository _gameboardrepository;

        public BoardRestConsumeController(IGameBoardRepository gameboardrepository)
        {
            _gameboardrepository = gameboardrepository;
        }
        public async Task<ActionResult> GetAllBoard()
        {

            //var getboards = await _gameboardrepository.GetAllAsync();
            //return View(getboards);

            return Ok();
        }

        // GET: GameRestConsume/Details/5
        public async Task<ActionResult> GetBoardById(int id)
        {
            //var getboardbyid = await _gameboardrepository.GetByIdAsync(id);
            //return View(getboardbyid);

            return Ok();
        }

        // GET: GameRestConsume/Create
        public async Task<ActionResult> CreateBoard([FromBody]Board board)
        {
            //var createdBoard = await _gameboardrepository.AddAsync(board);

            return null;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateGame([FromBody]Board board)
        {
            try
            {
                //var UpdateGames = await _gameboardrepository.UpdateAsync(board);
                //return RedirectToAction(nameof(GetAllBoard));

                return Ok();
            }
            catch
            {
                return RedirectToAction(nameof(GetAllBoard));
            }
        }

        // GET: GameRestConsume/Delete/5
        public async Task<ActionResult> DeleteGames([FromBody]Board board)
        {
            //var Deletegame = await _gameboardrepository.DeleteAsync(board);
            return RedirectToAction(nameof(GetAllBoard));

        }
    }
}