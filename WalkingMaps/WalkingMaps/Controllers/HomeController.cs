using Microsoft.AspNetCore.Mvc;

namespace WalkingMaps.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/ //entry point to the website
        public IActionResult Index()
        {
            return View();
        }
    }
}
