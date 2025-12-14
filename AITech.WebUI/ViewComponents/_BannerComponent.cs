using AITech.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _BannerComponent(IBannerService _bannerService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _bannerService.GetAllAsync();
            var value = values.OrderByDescending(x => x.Id).FirstOrDefault();
            return View(value);
        }
    }
}
