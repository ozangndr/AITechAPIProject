using AITech.WebUI.DTOs.FAQDtos;

namespace AITech.WebUI.Services.FAQServices
{
    public interface IFAQService
    {
        Task<List<ResultFAQDto>> GetAllAsync();
        Task<UpdateFAQDto> GetByIdAsync(int id);
        Task CreateAsync(CreateFAQDto createFAQDto);
        Task UpdateAsync(UpdateFAQDto updateFAQDto);
        Task DeleteAsync(int id);
    }
}
