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
        public async Task<IActionResult> GetProjects()
        {
            var values=await _projectService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            await _projectService.TCreateAsync(createProjectDto);
            return Ok("Yeni Proje Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            await _projectService.TUpdateAsync(updateProjectDto);
            return Ok("Proje Güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _projectService.TDeleteAsync(id);
            return Ok("Proje Silindi.");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _projectService.TGetByIdAsync(id);
            return Ok(value);
        }
    }
}
