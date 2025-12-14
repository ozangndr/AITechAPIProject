using AITech.WebUI.Services.FAQServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _FaqComponent(IFAQService _fAQService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _fAQService.GetAllAsync();
            return View(values);
        }
    }
}
