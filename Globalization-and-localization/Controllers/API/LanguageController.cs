using Microsoft.AspNetCore.Mvc;

namespace Globalization_and_localization.Controllers.API
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
