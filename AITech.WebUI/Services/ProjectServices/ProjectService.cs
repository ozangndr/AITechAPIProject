using AITech.WebUI.DTOs.ProjectDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.ProjectServices
{
    public class ProjectService
    {
        private readonly HttpClient _client;

        public ProjectService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateProjectDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Projects", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Projects/" + id);
        }

        public async Task<List<ResultProjectDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Projects");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProjectDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateProjectDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Projects" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateProjectDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateProjectDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Projects", content);

        }
    }
}
