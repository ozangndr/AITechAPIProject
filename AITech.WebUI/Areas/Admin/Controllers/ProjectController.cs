using AITech.WebUI.DTOs.ProjectDtos;
using AITech.WebUI.Services.CategoryServices;
using AITech.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController(IProjectService _projectService,ICategoryService _categoryService) : Controller
    {
        private async Task GetCategories()
        {
            // API'den tüm kategori listesini asenkron olarak çeker
            var values = await _categoryService.GetAllAsync();

            // LINQ kullanarak List<SelectListItem> formatına dönüştürür.
            List<SelectListItem> categoryList = (from x in values
                                                                                    select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                                                                                    {
                                                                                        Text = x.Name,
                                                                                        Value = x.Id.ToString()
                                                                                    }).ToList();

            // Dönüştürülmüş listeyi ViewBag'e atar
            ViewBag.CategoryList = categoryList;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _projectService.GetAllAsync();
            return View(values);
        }


        public async Task<IActionResult> Create()
        {
            await GetCategories();
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
            await GetCategories();
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
