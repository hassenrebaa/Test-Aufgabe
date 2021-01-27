using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Aufgabe.Models;
using Test_Aufgabe.Models.Repositories;

namespace Test_Aufgabe.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository<User> UserRepository;
        public UserController(IUserRepository<User> _UserRepository)
        {
            this.UserRepository = _UserRepository;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var users = UserRepository.List();
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details( int id)
        {
            var user = UserRepository.Find(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }
        // Anmelden Methode

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserRepository.Add(user);
                    var newuser = user.id;
                    var k = UserRepository.List().Max(b=>b.id);
                    if(k== newuser)
                    {
                        return RedirectToAction(nameof(Details), new { id = newuser });
                    }
                    
                }
                catch
                {
                    return View();
                }
            }
            ModelState.AddModelError("", "Etwas stimmt leider nicht !");
            return View("Create", new User());
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
