using AITech.WebUI.DTOs.CategoryDtos;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

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

        public async Task CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var json=JsonConvert.SerializeObject(createCategoryDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Categories", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Categories/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Categories");
            if(! response.IsSuccessStatusCode)
            {
                throw new Exception("Kategori listesi alınamadı");
            }
            var jsonContent=await response.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Categories"+id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Kategori listesi alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var json = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Categories",content);

        }
    }
}
