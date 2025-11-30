using AITech.WebUI.DTOs.BannerDtos;
using AITech.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    public class BannerController(IBannerService _bannerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _bannerService.GetAllAsync();
            return View(categories);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto dto)
        {
            await _bannerService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var category = await _bannerService.GetByIdAsync(id);
            return View(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto dto)
        {
            await _bannerService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
