using AITech.WebUI.DTOs.ProjectDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.ProjectServices
{
    public class ProjectService:IProjectService
    {
        private readonly HttpClient _client;

        public ProjectService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateProjectDto dto)
        {
            await _client.PostAsJsonAsync("Projects", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Projects/" + id);
        }

        public async Task<List<ResultProjectDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProjectDto>>("Projects/WithCategories");    
        }

        public async Task<UpdateProjectDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateProjectDto>("Projects/"+id);
        }

        public async Task UpdateAsync(UpdateProjectDto dto)
        {

            await _client.PutAsJsonAsync("Projects", dto);

        }
    }
}
