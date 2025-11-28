using AITech.WebUI.DTOs.TestimonialDtos;

namespace AITech.WebUI.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task<UpdateTestimonialDto> GetByIdAsync(int id);
        Task CreateAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteAsync(int id);
    }
}
