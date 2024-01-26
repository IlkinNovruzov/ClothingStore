using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.ViewCompanents
{
    public class Slider:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
