using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Group3.Data;
using MVC_Group3.Models;

namespace MVC_Group3.Controllers
{
    public class AdminShoeController : Controller
    {
        private readonly ApplicationDbContext db;

        public AdminShoeController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Admin/Shoe
        public IActionResult Index()
        {
            var shoes = db.Shoes.ToList();
            return View(shoes);
        }

        // GET: Admin/Shoe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Shoe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                db.Shoes.Add(shoe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoe);
        }

        // GET: Admin/Shoe/Edit/5
        public IActionResult Edit(int id)
        {
            var shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return NotFound();
            }
            return View(shoe);
        }

        // POST: Admin/Shoe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoe).State = EntityState.Modified;  // Sửa dòng này
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoe);
        }

        // GET: Admin/Shoe/Delete/5
        public IActionResult Delete(int id)
        {
            var shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return NotFound();
            }
            return View(shoe);
        }

        // POST: Admin/Shoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var shoe = db.Shoes.Find(id);
            db.Shoes.Remove(shoe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
