using AITech.WebUI.DTOs.AboutDtos;

namespace AITech.WebUI.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task<UpdateAboutDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutDto createAboutDto);
        Task UpdateAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAsync(int id);

    }
}
