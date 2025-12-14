using AITech.WebUI.Services.ChooseServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _ChooseComponent(IChooseService _chooseService): ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _chooseService.GetAllAsync();
            var value = values.OrderByDescending(x => x.Id).FirstOrDefault();
            return View(value);
        }
    }
}
