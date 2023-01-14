using Microsoft.AspNetCore.Mvc;

namespace Fair_ex.Controllers
{
    public class TemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
