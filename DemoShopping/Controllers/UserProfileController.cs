using Microsoft.AspNetCore.Mvc;

namespace DemoShopping.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
