using Microsoft.AspNetCore.Mvc;

namespace Fair_ex.Controllers
{
    public class FeiraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
