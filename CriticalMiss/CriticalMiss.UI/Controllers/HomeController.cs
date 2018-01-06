using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CriticalMiss.UI.Models;

namespace CriticalMiss.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult CreateGames()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult CreateGames(Dac.Games games)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Dac.DataAccess Repo = new Dac.DataAccess();
        //            if (Repo.CreateGames(games))
        //            {
        //                ViewBag.Message = "Game Added Succesfully...";
        //            }
        //        }
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "Failed To create new Please try again later";
        //        return View();
        //        // throw;
        //    }
        //}
    }
}
