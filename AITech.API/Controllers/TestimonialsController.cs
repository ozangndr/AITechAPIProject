using AITech.Business.Services.TestimonialServices;
using AITech.DTO.TestimonialDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService _testimonialService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _testimonialService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _testimonialService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            await _testimonialService.TCreateAsync(dto);
            return Ok("Yeni Kayıt Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            await _testimonialService.TUpdateAsync(dto);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialService.TDeleteAsync(id);
            return Ok("Kayıt Silindi.");
        }
    }
}
