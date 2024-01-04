using ClothingShop.DTO;
using ClothingShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLogin appUserLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(appUserLogin.Username, appUserLogin.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(appUserLogin.Username);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
