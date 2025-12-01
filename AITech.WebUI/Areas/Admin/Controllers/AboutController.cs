using AITech.WebUI.DTOs.AboutDtos;
using AITech.WebUI.Services.AboutServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto dto)
        {
            await _aboutService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update()
        {
            var values = await _aboutService.GetAllAsync();
            var value = values.OrderByDescending(x=>x.Id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto dto)
        {
            await _aboutService.UpdateAsync(dto);
            return RedirectToAction("Update");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
