using AITech.WebUI.DTOs.CategoryDtos;

namespace AITech.WebUI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            await _client.PostAsJsonAsync("Categories", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Categories/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCategoryDto>>("Categories");
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateCategoryDto>("Categories/" + id);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            await _client.PutAsJsonAsync("Categories", dto);

        }
    }
}
