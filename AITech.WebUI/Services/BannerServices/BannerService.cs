using AITech.WebUI.DTOs.BannerDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.BannerServices
{
    public class BannerService
    {
        private readonly HttpClient _client;

        public BannerService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateBannerDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Banners", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Banners/" + id);
        }

        public async Task<List<ResultBannerDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Banners");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateBannerDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Banners" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateBannerDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateBannerDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Banners", content);

        }
    }
}
