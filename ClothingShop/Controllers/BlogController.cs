using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class BlogController : Controller
    {
        private readonly MyDbContext _context;
        public BlogController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Blog()
        {
            return View(_context.Blogs.ToList());
        }
        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}
