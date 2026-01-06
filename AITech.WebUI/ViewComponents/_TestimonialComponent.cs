using AITech.WebUI.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _TestimonialComponent(ITestimonialService _testimonialService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values=await _testimonialService.GetAllAsync();
            return View(values);
        }
    }
}
