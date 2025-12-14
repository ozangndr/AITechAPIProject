using AITech.WebUI.Services.AboutItemServices;
using AITech.WebUI.Services.AboutServices;
using AITech.WebUI.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _AboutComponent(IAboutService _aboutService,IAboutItemService _aboutItemService,ISocialService _socialService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAsync();
            var value = values.OrderByDescending(x => x.Id).FirstOrDefault();
            var aboutItems = await _aboutItemService.GetAllAsync();
            ViewBag.AboutItems = aboutItems;
            var socialValues = await _socialService.GetAllAsync();
            ViewBag.SocialValues = socialValues;

            return View(value);
        }
    }
}
