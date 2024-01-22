using ClothingShop.DTO;
using ClothingShop.Extensions;
using ClothingShop.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace ClothingShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager, IEmailService emailService)
        {
            _emailService = emailService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegister appUserRegister)
        {
            if (ModelState.IsValid)
            {
                Random random=new Random();
                int code;
                code= random.Next(100000, 1000000);
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegister.Username,
                    Email = appUserRegister.Email,
                    Name = appUserRegister.Name,
                    Surname = appUserRegister.Surname,
                    ConfirmCode = code
                };
                var result= await _userManager.CreateAsync(appUser,appUserRegister.Password);
                if (result.Succeeded)
                {
                    await _emailService.SendEmailAsync(appUser.Email,"Confirm Email",$"{code}");
                    

                    TempData["mail"] = appUserRegister.Email;
                    return RedirectToAction("ConfirmMail", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(appUserRegister);
        }
    }
}
