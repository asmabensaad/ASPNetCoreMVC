using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
