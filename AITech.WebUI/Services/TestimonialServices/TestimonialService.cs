using AITech.WebUI.DTOs.TestimonialDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.TestimonialServices
{
    public class TestimonialService
    {
        private readonly HttpClient _client;

        public TestimonialService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateTestimonialDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync("Testimonials", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Testimonials/" + id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var response = await _client.GetAsync("Testimonials");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var jsonContent = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonContent);
            return values;
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            var response = await _client.GetAsync("Testimonials" + id);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Liste alınamadı");
            }
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(json);
            return value;
        }

        public async Task UpdateAsync(UpdateTestimonialDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync("Testimonials", content);

        }
    }
}
}
