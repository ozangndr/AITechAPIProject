using AITech.Business.Services.AboutItemServices;
using AITech.DTO.AboutItemDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutItemController(IAboutItemService _aboutItemService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _aboutItemService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value=await _aboutItemService.TGetByIdAsync(id);
            if (value == null)
            {
                throw new Exception("HHakkımızda item bulunamadı");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutItemDto createAboutItemDto)
        {
            await _aboutItemService.TCreateAsync(createAboutItemDto);
            return Ok("Hakkımızda item Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutItemDto updateAboutItemDto)
        {
            await _aboutItemService.TUpdateAsync(updateAboutItemDto);
            return Ok("Hakkımızda item güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutItemService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
