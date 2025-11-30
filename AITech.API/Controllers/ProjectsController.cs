using AITech.Business.Services.ProjectServices;
using AITech.DTO.ProjectDtos;
using AITech.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService _projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values=await _projectService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("WithCategories")]
        public async Task<IActionResult> GetAllWithCategories()
        {
            var values = await _projectService.TGetProjectWithCategoriesAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            await _projectService.TCreateAsync(createProjectDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            await _projectService.TUpdateAsync(updateProjectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.TDeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _projectService.TGetByIdAsync(id);
            if (value is null)
            {
                return BadRequest("Proje Bulunamadı");
            }
            return Ok(value);
        }
    }
}
