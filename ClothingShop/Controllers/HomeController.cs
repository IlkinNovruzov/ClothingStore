using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ClothingShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;
        public HomeController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }

        public IActionResult Blog()
        {
           return View(_context.Blogs.ToList());
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}