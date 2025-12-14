using AITech.WebUI.Services.StaffServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _StaffComponent(IStaffService _staffService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values= await _staffService.GetAllAsync();
            return View(values);
        }
    }
}
