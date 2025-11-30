using AITech.WebUI.DTOs.TestimonialDtos;
using AITech.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController(ITestimonialService _testimonialService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            await _testimonialService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var value = await _testimonialService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            await _testimonialService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
