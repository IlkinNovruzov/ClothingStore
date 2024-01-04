using ClothingShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ConfirmMail()
        {
            ViewBag.mail = TempData["mail"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmMail(string mail,int code)
        {
            var user = await _userManager.FindByEmailAsync(mail);
            if (user.ConfirmCode == code)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}
