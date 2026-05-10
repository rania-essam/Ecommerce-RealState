using Microsoft.AspNetCore.Mvc;

namespace ECommerce.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
