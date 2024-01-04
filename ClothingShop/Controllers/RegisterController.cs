using ClothingShop.DTO;
using ClothingShop.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace ClothingShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
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
                    var msg = new MimeMessage();
                    var mailFrom = new MailboxAddress("Admin", "uomostore004@gmail.com");
                    var mailTo = new MailboxAddress("User", appUser.Email);

                    msg.From.Add(mailFrom);
                    msg.To.Add(mailTo);
                    var bodyBuilder=new BodyBuilder();
                    bodyBuilder.TextBody = "Confirm Code:" + code;
                    msg.Body=bodyBuilder.ToMessageBody();
                    msg.Subject = "Project Confirm Code";

                    SmtpClient client=new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("uomostore004@gmail.com", "qgrh mqlg lrni irjh");
                    client.Send(msg);
                    client.Disconnect(true);

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
