using AITech.WebUI.DTOs.MessageDtos;
using AITech.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController(IMessageService _messageService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values=await _messageService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Read(int id)
        {
            // Mesajı ID ile çek
            var message = await _messageService.GetByIdAsync(id); 

            if (message == null)
            {
                return NotFound(); 
            }            
            return Json(new
            {
                id = message.Id,
                name = message.Name,
                email = message.Email,
                subject = message.Subject,
                messageBody = message.Body 
            });
        }

    }
}
