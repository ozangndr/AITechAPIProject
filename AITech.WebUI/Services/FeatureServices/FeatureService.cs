using AITech.WebUI.DTOs.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.FeatureServices
{
    public class FeatureService
    {
        private readonly HttpClient _client;

        public FeatureService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateFeatureDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Features", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Features/" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Features");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateFeatureDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Features" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateFeatureDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Features", content);

        }
    }
}
