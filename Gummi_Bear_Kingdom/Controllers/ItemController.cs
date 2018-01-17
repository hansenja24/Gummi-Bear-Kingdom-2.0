using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gummi_Bear_Kingdom.Models;
using Microsoft.EntityFrameworkCore;

namespace Gummi_Bear_Kingdom.Controllers
{
    public class ItemController : Controller
    {
        private IItemRepository itemRepo;

        public ItemController(IItemRepository repo = null)
        {
            if (repo == null)
            {
                this.itemRepo = new EFItemRepository();
            }
            else
            {
                this.itemRepo = repo;
            }
        }

        public ViewResult Index()
        {
            return View(itemRepo.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            Product thisItem = itemRepo.Items.FirstOrDefault(x => x.ProductId == id);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Product thisItem = itemRepo.Items.FirstOrDefault(x => x.ProductId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Product item)
        {
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product thisItem = itemRepo.Items.FirstOrDefault(x => x.ProductId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product thisItem = itemRepo.Items.FirstOrDefault(x => x.ProductId == id);
            itemRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }
    }
}
