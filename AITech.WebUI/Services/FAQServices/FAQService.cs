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
            await _client.PostAsJsonAsync("FAQs", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("FAQs/" + id);
        }

        public async Task<List<ResultFAQDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFAQDto>>("FAQs");
        }

        public async Task<UpdateFAQDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateFAQDto>("FAQs/" + id);
        }

        public async Task UpdateAsync(UpdateFAQDto dto)
        {
            await _client.PutAsJsonAsync("FAQs", dto);

        }
    }
}
