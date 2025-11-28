using AITech.WebUI.DTOs.AboutItemDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.AboutItemServices
{
    public class AboutItemService
    {
        private readonly HttpClient _client;

        public AboutItemService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateAboutItemDto createAboutItemDto)
        {
            var json = JsonConvert.SerializeObject(createAboutItemDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("AboutItems", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("AboutItems/" + id);
        }

        public async Task<List<ResultAboutItemDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("AboutItems");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutItemDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateAboutItemDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("AboutItems" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateAboutItemDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateAboutItemDto updateCategoryDto)
        {
            var json = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("AboutItems", content);

        }
    }
}
