using AITech.WebUI.DTOs.SocialDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.SocialServices
{
    public class SocialService:ISocialService
    {
        private readonly HttpClient _client;

        public SocialService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateSocialDto dto)
        {
            await _client.PostAsJsonAsync("Socials", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Socials/" + id);
        }

        public async Task<List<ResultSocialDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultSocialDto>>("Socials");
        }

        public async Task<UpdateSocialDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateSocialDto>("Socials/" + id);
        }

        public async Task UpdateAsync(UpdateSocialDto dto)
        {
            await _client.PutAsJsonAsync("Socials", dto);

        }
    }
}
