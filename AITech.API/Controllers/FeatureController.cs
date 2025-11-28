using AITech.Business.Services.FeatureServices;
using AITech.DTO.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController(IFeatureService _featureService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _featureService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value=await _featureService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            await _featureService.TCreateAsync(createFeatureDto);
            return Ok("Kayıt oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.TUpdateAsync(updateFeatureDto);
            return Ok("Kayıt güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _featureService.TDeleteAsync(id);
            return NoContent();
        }


    }
}
