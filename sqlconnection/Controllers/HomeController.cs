using Microsoft.AspNetCore.Mvc;

namespace sqlconnection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
