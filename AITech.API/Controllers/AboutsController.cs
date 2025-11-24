using AITech.Business.Services.AboutServices;
using AITech.DTO.AboutDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values =await _aboutService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value =await _aboutService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _aboutService.TCreateAsync(createAboutDto);
            return Ok("Hakkımızda bilgisi eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.TUpdateAsync(updateAboutDto);
            return Ok("Hakkımızda bilgisi güncellendi");
        }

        [HttpDelete] 
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.TDeleteAsync(id);
            return Ok("Hakkımızda bilgisi silindi");
        }
    }
}
