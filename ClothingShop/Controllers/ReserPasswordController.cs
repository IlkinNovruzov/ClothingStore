using ClothingShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class ReserPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ReserPasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string mail)
        {
            //var user = await _userManager.FindByEmailAsync(mail);
            //if (user.ConfirmCode == )
            //{
            //    user.EmailConfirmed = true;
            //    await _userManager.UpdateAsync(user);
            //    return RedirectToAction("Login", "Login");
            //}
            return View();
        }
       
    }
}
