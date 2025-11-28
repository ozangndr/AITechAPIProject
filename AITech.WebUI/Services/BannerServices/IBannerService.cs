using AITech.WebUI.DTOs.BannerDtos;

namespace AITech.WebUI.Services.BannerServices
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> GetAllAsync();
        Task<UpdateBannerDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBannerDto createBannerDto);
        Task UpdateAsync(UpdateBannerDto updateBannerDto);
        Task DeleteAsync(int id);
    }
}
