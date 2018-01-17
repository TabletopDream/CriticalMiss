using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CriticalMiss.Common.Interfaces;
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

            var getgames=await _gamerepository.GetAllAsync();
            return View(getgames);
        }

        // GET: GameRestConsume/Details/5
        public async Task<ActionResult> GetGameById(int id)
        {
            //var getgamebyid = await _gamerepository.GetByIdAsync(id);
            //return View(getgamebyid);
            return null;
        }

        // GET: GameRestConsume/Create
        public async Task<ActionResult> Create([FromBody] Game game)
        {
            var createdGame = await _gamerepository.AddAsync(game);

            return null;
        }

        // POST: GameRestConsume/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(GetAllGame));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameRestConsume/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameRestConsume/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(GetAllGame));
            }
            catch
            {
                return View();
            }
        }

        // GET: GameRestConsume/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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