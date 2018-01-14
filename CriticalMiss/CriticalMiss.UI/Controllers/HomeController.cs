using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lib = CriticalMiss.Library.Models;

namespace CriticalMiss.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() //Home Page
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User u)
        {
            // lib.User User = new lib.User();
            // if(RegisteredUser(u.UserName, u.Password))
            // {
            //     return RedirectToAction(nameof(Details));
            // }
            // return View();
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details() // List of Games , Game Browswer
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create() // Registration
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) // Registration after clicking the register button
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}