using AITech.WebUI.DTOs.SocialDtos;
using AITech.WebUI.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController(ISocialService _socialService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _socialService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialDto dto)
        {
            await _socialService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var value = await _socialService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialDto dto)
        {
            await _socialService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _socialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
