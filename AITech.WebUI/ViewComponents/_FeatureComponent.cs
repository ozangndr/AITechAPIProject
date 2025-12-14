using AITech.WebUI.Services.CategoryServices;
using AITech.WebUI.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _FeatureComponent(IFeatureService _featureService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _featureService.GetAllAsync();
            return View(values);
        }
    }
}
