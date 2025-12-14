using AITech.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _ProjectComponent(IProjectService _projectService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _projectService.GetAllAsync();
            return View(values);
        }
    }
}
