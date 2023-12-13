using Microsoft.AspNetCore.Mvc;

namespace Tienda.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
