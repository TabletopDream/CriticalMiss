using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CriticalMiss.Common.Interfaces;
using CriticalMiss.Data.Models;
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
        
            return View();
        }

        // GET: GameRestConsume/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameRestConsume/Create
        public ActionResult Create()
        {
            return View();
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