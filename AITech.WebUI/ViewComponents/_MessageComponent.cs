using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.ViewComponents
{
    public class _MessageComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {     
           
            return View();
        }
    }
}
