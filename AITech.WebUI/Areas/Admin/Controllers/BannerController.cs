using AITech.WebUI.DTOs.BannerDtos;
using AITech.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController(IBannerService _bannerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _bannerService.GetAllAsync();
            return View(values);
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


        public async Task<IActionResult> Update()
        {
            var values = await _bannerService.GetAllAsync();
            var value=values.OrderByDescending(x => x.Id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerDto dto)
        {
            await _bannerService.UpdateAsync(dto);
            return RedirectToAction("Update");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
