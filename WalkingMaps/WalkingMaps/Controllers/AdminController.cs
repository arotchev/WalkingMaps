using Microsoft.AspNetCore.Mvc;

namespace WalkingMaps.Controllers
{
    public class AdminController : Controller
    {
        //get main page for SPA
        public IActionResult Index()
        {
            return View();
        }
    }
}