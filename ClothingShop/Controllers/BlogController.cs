using ClothingShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
        [Authorize]
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
