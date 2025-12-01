using AITech.WebUI.DTOs.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.FeatureServices
{
    public class FeatureService:IFeatureService
    {
        private readonly HttpClient _client;

        public FeatureService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateFeatureDto dto)
        {
            await _client.PostAsJsonAsync("Features", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Features/" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureDto>>("Features");
        }

        public async Task<UpdateFeatureDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateFeatureDto>("Features/" + id);
        }

        public async Task UpdateAsync(UpdateFeatureDto dto)
        {
            await _client.PutAsJsonAsync("Features", dto);

        }
    }
}
