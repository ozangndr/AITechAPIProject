using AITech.WebUI.Services.GeminiServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Controllers
{
    public class GeminiController(IGeminiService _geminiService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string prompt)
        {
            var response=await _geminiService.GetGeminiDataAsync(prompt);
            if(response!=null)
            { 
                ViewBag.response=response;
                
            }
            return View();

        }
    }
}
