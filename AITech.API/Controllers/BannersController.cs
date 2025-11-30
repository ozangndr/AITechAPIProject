using AITech.Business.Services.BannerServices;
using AITech.DTO.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IBannerService _bannerService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _bannerService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value=await _bannerService.TGetByIdAsync(id);
            if(value is null)
            {
                throw new Exception("Banner bulunamadı");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            await _bannerService.TCreateAsync(createBannerDto);
            return Ok("Banner oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.TUpdateAsync(updateBannerDto);
            return Ok("Banner güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
