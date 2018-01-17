using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi_Bear_Kingdom.Models;

namespace Gummi_Bear_Kingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private GummiBearKingdomDbContext db = new GummiBearKingdomDbContext();

        public IActionResult Index()
        {
            return View(db.Reviews.Include(items => items.Products).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisReview = db.Reviews.Include(items => items.Products).ToList().FirstOrDefault(items => items.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Create(Review item)
        {
            db.Reviews.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisReview = db.Reviews.Include(items => items.Products).FirstOrDefault(items => items.ReviewId == id);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
            db.Reviews.Remove(thisReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}