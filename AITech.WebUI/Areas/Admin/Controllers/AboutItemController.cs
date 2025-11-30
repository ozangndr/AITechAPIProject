using AITech.WebUI.DTOs.AboutItemDtos;
using AITech.WebUI.Services.AboutItemServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutItemController(IAboutItemService _aboutItemService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _aboutItemService.GetAllAsync();
            return View(categories);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutItemDto dto)
        {
            await _aboutItemService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var category = await _aboutItemService.GetByIdAsync(id);
            return View(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutItemDto dto)
        {
            await _aboutItemService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
