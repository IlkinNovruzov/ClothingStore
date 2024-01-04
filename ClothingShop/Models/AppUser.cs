using Microsoft.AspNetCore.Identity;

namespace ClothingShop.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ConfirmCode { get; set; }
    }
}
