using Microsoft.AspNetCore.Mvc;
using NotepadWeb.Data;
using NotepadWeb.Models;

namespace NotepadWeb.Controllers
{
    public class NotepadController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NotepadController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Notepad> objNotepadList = _db.Notepads.ToList();
            return View(objNotepadList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Notepad obj)
        {
            if (ModelState.IsValid)
            {
                _db.Notepads.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Notepad added successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var notepadFromDb = _db.Notepads.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (notepadFromDb == null)
            {
                return NotFound();
            }

            return View(notepadFromDb);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Notepad obj)
        {
            if (ModelState.IsValid)
            {
                _db.Notepads.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Notepad updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var notepadFromDb = _db.Notepads.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (notepadFromDb == null)
            {
                return NotFound();
            }

            return View(notepadFromDb);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = _db.Notepads.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Notepads.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Notepad deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
