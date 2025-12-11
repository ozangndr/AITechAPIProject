using AITech.WebUI.DTOs.StaffDtos;

namespace AITech.WebUI.Services.StaffServices
{
    public class StaffService:IStaffService
    {
        private readonly HttpClient _client;

        public StaffService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateStaffDto dto)
        {
            await _client.PostAsJsonAsync("Staffs", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Staffs/" + id);
        }

        public async Task<List<ResultStaffDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultStaffDto>>("Staffs");
        }

        public async Task<UpdateStaffDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateStaffDto>("Staffs/" + id);
        }

        public async Task UpdateAsync(UpdateStaffDto dto)
        {
            await _client.PutAsJsonAsync("Staffs", dto);

        }
    }
}
