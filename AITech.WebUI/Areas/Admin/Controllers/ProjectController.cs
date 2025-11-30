using AITech.WebUI.DTOs.ProjectDtos;
using AITech.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController(IProjectService _projectService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _projectService.GetAllAsync();
            return View(values);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            await _projectService.CreateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var value = await _projectService.GetByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProjectDto dto)
        {
            await _projectService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _projectService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
