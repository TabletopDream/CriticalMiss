using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CriticalMiss.Common.Interfaces;
using CriticalMiss.Data.Models;
using CriticalMiss.UI.Models;
using CriticalMiss.UI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CriticalMiss.UI.Controllers.API
{
    public class GameRestConsumeController : Controller
    {
        private IGameRepository _gamerepository;

        public GameRestConsumeController(IGameRepository gamerepository)
        {
            _gamerepository = gamerepository;
        }

        // GET: GameRestConsume
        public async Task<ActionResult> GetAllGame()
        {

            var getgames = await _gamerepository.GetAllAsync();
            return View(getgames);
        }

        // GET: GameRestConsume/Details/5
        public async Task<ActionResult> GetGameById(int id)
        {
            var getgamebyid = await _gamerepository.GetByIdAsync(id);
            return View(getgamebyid);
        }

        // GET: GameRestConsume/Create
        public async Task<ActionResult> CreateGame([FromBody] Game game)
        {
            var createdGame = await _gamerepository.AddAsync(game);

            return null;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateGame([FromBody] Game game)
        {
            try
            {
                var UpdateGames = await _gamerepository.UpdateAsync(game);
                return RedirectToAction(nameof(GetAllGame));
            }
            catch
            {
                return RedirectToAction(nameof(GetAllGame));
            }
        }

        // GET: GameRestConsume/Delete/5
        public async Task<ActionResult> DeleteGames([FromBody]Game game)
        {
            var Deletegame = await _gamerepository.DeleteAsync(game);
            return RedirectToAction(nameof(GetAllGame));

        }

        // POST: GameRestConsume/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(GetAllGame));
            }
            catch
            {
                return View();
            }
        }
    }
}