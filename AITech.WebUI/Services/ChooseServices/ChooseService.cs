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
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Chooses", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Chooses/" + id);
        }

        public async Task<List<ResultChooseDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Chooses");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultChooseDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateChooseDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Chooses" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateChooseDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateChooseDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Chooses", content);

        }
    }
}
