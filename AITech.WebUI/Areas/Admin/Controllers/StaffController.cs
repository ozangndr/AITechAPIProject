using AITech.WebUI.DTOs.StaffDtos;
using AITech.WebUI.Services.StaffServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController(IStaffService _staffService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _staffService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffDto dto)
        {
            await _staffService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var value = await _staffService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStaffDto dto)
        {
            await _staffService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
