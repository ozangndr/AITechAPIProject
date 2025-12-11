using AITech.Business.Services.StaffServices;
using AITech.DTO.StaffDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController(IStaffService _staffService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _staffService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _staffService.TGetByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStaffDto createStaffDto)
        {
            await _staffService.TCreateAsync(createStaffDto);
            return Ok("Kayıt oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStaffDto updateStaffDto)
        {
            await _staffService.TUpdateAsync(updateStaffDto);
            return Ok("Kayıt güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
