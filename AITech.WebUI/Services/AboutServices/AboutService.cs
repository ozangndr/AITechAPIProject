using AITech.WebUI.DTOs.AboutDtos;

namespace AITech.WebUI.Services.AboutServices
{
    public class AboutService:IAboutService
    {
        private readonly HttpClient _client;

        public AboutService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateAboutDto dto)
        {
            await _client.PostAsJsonAsync("Abouts", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Abouts/" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultAboutDto>>("Abouts");
        }

        public async Task<UpdateAboutDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateAboutDto>("Abouts/" + id);
        }

        public async Task UpdateAsync(UpdateAboutDto dto)
        {
            await _client.PutAsJsonAsync("Abouts", dto);

        }
    }
}
