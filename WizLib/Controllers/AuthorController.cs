using Microsoft.AspNetCore.Mvc;
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
            List<Author> authorList = _db.Authors.ToList();
            return View(authorList);
        }

        public IActionResult Upsert(int? id)
        {
            Author author = new Author();
            if (id == null)
            {
                return View(author);
            }
            author = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    _db.Authors.Add(obj);
                }
                else
                {
                    _db.Authors.Update(obj);
                }
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            _db.Authors.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
