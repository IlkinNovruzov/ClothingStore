using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly MyDbContext _context;
        public BlogController(MyDbContext context)
        {
            _context=context;
        }
        public IActionResult Blog()
        {
            return View(_context.Blogs.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Blog");
        }
    }
}
