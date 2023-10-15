﻿using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

namespace WizLib.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id) 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }


    }
}
