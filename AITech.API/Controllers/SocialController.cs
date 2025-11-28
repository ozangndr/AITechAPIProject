using AITech.Business.Services.SocialServices;
using AITech.DTO.FeatureDtos;
using AITech.DTO.SocialDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController(ISocialService _socialService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _socialService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value=await _socialService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialDto createSocialDto)
        {
            await _socialService.TCreateAsync(createSocialDto);
            return Ok("Kayıt oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialDto updateSocialDto)
        {
            await _socialService.TUpdateAsync(updateSocialDto);
            return Ok("Kayıt güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _socialService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
