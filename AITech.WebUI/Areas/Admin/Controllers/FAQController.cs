using AITech.WebUI.DTOs.FAQDtos;
using AITech.WebUI.Services.FAQServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FAQController(IFAQService _fAQService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _fAQService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFAQDto dto)
        {
            await _fAQService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var value = await _fAQService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFAQDto dto)
        {
            await _fAQService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _fAQService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
