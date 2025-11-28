using AITech.Business.Services.FAQServices;
using AITech.DTO.FAQDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController(IFAQService _fAQService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _fAQService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value=await _fAQService.TGetByIdAsync(id);
            if (value is null)
            {
                throw new Exception("Kayıt bulunamadı");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFAQDto createFAQDto)
        {
            await _fAQService.TCreateAsync(createFAQDto);
            return Ok("Kayıt oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFAQDto updateFAQDto)
        {
            await _fAQService.TUpdateAsync(updateFAQDto);
            return Ok("Kayıt güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fAQService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
