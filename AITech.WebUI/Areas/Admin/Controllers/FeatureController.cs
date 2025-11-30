using AITech.WebUI.DTOs.FeatureDtos;
using AITech.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController(IFeatureService _featureService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var values = await _featureService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto dto)
        {
            await _featureService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var value = await _featureService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureDto dto)
        {
            await _featureService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _featureService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
