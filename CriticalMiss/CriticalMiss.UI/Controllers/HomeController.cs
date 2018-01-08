using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.Data;
using CriticalMiss.Data.Models;
using CriticalMiss.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace CriticalMiss.UI.Controllers
{
    public class HomeController : Controller
    {
        private CriticalMissDbContext _context;

        public HomeController(CriticalMissDbContext context)
        {
            _context = context;
        }
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
            return null;
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult CreateGames()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGames(TabletopGame creategames)
        {
            var dob = new Games()
            {
                UserName = creategames.UserName,
                GameName=creategames.GameName,
                Password=creategames.Password   
            };
            _context.Add(dob);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult GetGames()
        {
            var dob = _context.games.AsEnumerable();
            return View(dob);
        }
        [HttpGet]
        public ActionResult GetGames(string username)
        {
            var dob = _context.games.Where(a => a.UserName == username).AsEnumerable();
            return View(dob);
        }

    }
}
