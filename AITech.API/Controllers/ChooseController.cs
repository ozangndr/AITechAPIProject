using AITech.Business.Services.ChooseServices;
using AITech.DTO.ChooseDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChooseController(IChooseService _chooseService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GatAll()
        {
            var values = await _chooseService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _chooseService.TGetByIdAsync(id);
            if (value == null)
            {
                throw new Exception("Kayıt bulunamadı");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChooseDto createChooseDto)
        {
            await _chooseService.TCreateAsync(createChooseDto);
            return Ok("Kayıt oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateChooseDto updateChooseDto)
        {
            await _chooseService.TUpdateAsync(updateChooseDto);
            return Ok("Kayıt güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _chooseService.TDeleteAsync(id);
            return NoContent();
        }

    }
}
