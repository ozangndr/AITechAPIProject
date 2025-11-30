using AITech.WebUI.DTOs.ChooseDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.ChooseServices
{
    public class ChooseService
    {
        private readonly HttpClient _client;

        public ChooseService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateChooseDto dto)
        {
            await _client.PostAsJsonAsync("Chooses", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Chooses/" + id);
        }

        public async Task<List<ResultChooseDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultChooseDto>>("Chooses");
        }

        public async Task<UpdateChooseDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateChooseDto>("Chooses/" + id);
        }

        public async Task UpdateAsync(UpdateChooseDto dto)
        {
            await _client.PutAsJsonAsync("Chooses", dto);

        }
    }
}
