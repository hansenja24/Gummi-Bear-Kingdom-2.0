using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi_Bear_Kingdom.Models;

namespace Gummi_Bear_Kingdom.Controllers
{
    public class ProductsController : Controller
    {
        private GummiBearKingdomDbContext db = new GummiBearKingdomDbContext();

        public IActionResult Index()
        {
            return View(db.Products.Include(x => x.Reviews).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisProduct = db.Products.Include(x=>x.Reviews).FirstOrDefault(items => items.ProductId == id);
            return View(thisProduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(items => items.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(items => items.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProduct = db.Products.FirstOrDefault(items => items.ProductId == id);
            db.Products.Remove(thisProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}