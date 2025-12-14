using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Controllers
{
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
