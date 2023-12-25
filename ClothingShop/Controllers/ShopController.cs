using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;
        public ShopController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Shop()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(_context.Products.Include(x => x.Category).ToList());
        }
    }
}
