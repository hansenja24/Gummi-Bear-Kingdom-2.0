using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gummi_Bear_Kingdom.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace World_Travel_Blog
{
    public class HomeController : Controller
    {
        private GummiBearKingdomDbContext _db = new GummiBearKingdomDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> mostRecent = _db.Products.OrderByDescending(x => x.ProductId).Take(3).ToList();
            ViewData["mostRecent"] = mostRecent;
            return View();
        }
    }
}