using AITech.WebUI.DTOs.BannerDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.BannerServices
{
    public class BannerService:IBannerService
    {
        private readonly HttpClient _client;

        public BannerService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateBannerDto dto)
        {
            await _client.PostAsJsonAsync("Banners", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Banners/" + id);
        }

        public async Task<List<ResultBannerDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultBannerDto>>("Banners");
        }

        public async Task<UpdateBannerDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateBannerDto>("Banners/" + id);
        }

        public async Task UpdateAsync(UpdateBannerDto dto)
        {
            await _client.PutAsJsonAsync("Banners", dto);

        }
    }
}
