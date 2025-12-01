using AITech.WebUI.DTOs.ChooseDtos;
using AITech.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChooseController(IChooseService _chooseService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _chooseService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChooseDto dto)
        {
            await _chooseService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update()
        {
            var values = await _chooseService.GetAllAsync();
            var value = values.OrderByDescending(x => x.Id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateChooseDto dto)
        {
            await _chooseService.UpdateAsync(dto);
            return RedirectToAction("Update");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _chooseService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
