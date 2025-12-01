using AITech.WebUI.DTOs.AboutItemDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.AboutItemServices
{
    public class AboutItemService:IAboutItemService
    {
        private readonly HttpClient _client;

        public AboutItemService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateAboutItemDto dto)
        {
            await _client.PostAsJsonAsync("AboutItems", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("AboutItems/" + id);
        }

        public async Task<List<ResultAboutItemDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultAboutItemDto>>("AboutItems");
        }

        public async Task<UpdateAboutItemDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateAboutItemDto>("AboutItems/" + id);
        }

        public async Task UpdateAsync(UpdateAboutItemDto dto)
        {
            await _client.PutAsJsonAsync("AboutItems", dto);

        }
    }
}
