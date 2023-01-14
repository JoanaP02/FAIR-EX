using Microsoft.AspNetCore.Mvc;

namespace Fair_ex.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
