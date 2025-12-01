using AITech.WebUI.DTOs.TestimonialDtos;
using Newtonsoft.Json;
using System.Text;

namespace AITech.WebUI.Services.TestimonialServices
{
    public class TestimonialService:ITestimonialService
    {
        private readonly HttpClient _client;

        public TestimonialService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateTestimonialDto dto)
        {
            await _client.PostAsJsonAsync("Testimonials", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Testimonials/" + id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("Testimonials");
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateTestimonialDto>("Testimonials/" + id);
        }

        public async Task UpdateAsync(UpdateTestimonialDto dto)
        {
            await _client.PutAsJsonAsync("Testimonials", dto);

        }
    }
}

