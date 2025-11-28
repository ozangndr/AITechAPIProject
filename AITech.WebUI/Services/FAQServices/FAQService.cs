using AITech.WebUI.DTOs.FAQDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.FAQServices
{
    public class FAQService
    {
        private readonly HttpClient _client;

        public FAQService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateFAQDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("FAQs", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("FAQs/" + id);
        }

        public async Task<List<ResultFAQDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("FAQs");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFAQDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateFAQDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("FAQs" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFAQDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateFAQDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("FAQs", content);

        }
    }
}
