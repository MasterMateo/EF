using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess.Data;
using WizLib_Model.Models;

namespace WizLib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id) 
        {
            Category obj = new Category();
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _db.Categories.FirstOrDefault(u => u.Catrgory_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Catrgory_Id == 0)
                {
                    //this is create
                    _db.Categories.Add(obj);
                }
                else
                {
                    //this is update
                    _db.Categories.Update(obj);
                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _db.Categories.FirstOrDefault(u => u.Catrgory_Id==id);
            _db.Categories.Remove(objFromDb);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> catlist = new List<Category>();
            for (int i = 1;  i <= 2; i++)
            {
                catlist.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_db.Categories.Add(new Category { Name = Guid.NewGuid().ToString()});
            }
            _db.Categories.AddRange(catlist);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> catlist = new List<Category>();
            for (int i = 1; i <= 5; i++)
            {
                catlist.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_db.Categories.Add(new Category { Name = Guid.NewGuid().ToString()});
            }
            _db.Categories.AddRange(catlist);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<Category> catlist = _db.Categories.OrderByDescending(u => u.Catrgory_Id).Take(2).ToList();

            _db.Categories.RemoveRange(catlist);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            IEnumerable<Category> catlist = _db.Categories.OrderByDescending(u => u.Catrgory_Id).Take(5).ToList();

            _db.Categories.RemoveRange(catlist);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
