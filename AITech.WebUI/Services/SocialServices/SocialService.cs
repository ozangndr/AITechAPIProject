using AITech.WebUI.DTOs.SocialDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.SocialServices
{
    public class SocialService
    {
        private readonly HttpClient _client;

        public SocialService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateSocialDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Socials", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Socials/" + id);
        }

        public async Task<List<ResultSocialDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Projects");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateSocialDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Socials" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSocialDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateSocialDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Socials", content);

        }
    }
}
