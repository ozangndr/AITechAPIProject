using AITech.WebUI.DTOs.AboutItemDtos;

namespace AITech.WebUI.Services.AboutItemServices
{
    public interface IAboutItemService
    {
        Task<List<ResultAboutItemDto>> GetAllAsync();
        Task<UpdateAboutItemDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutItemDto createAboutItemDto);
        Task UpdateAsync(UpdateAboutItemDto updateAboutItemDto);
        Task DeleteAsync(int id);
    }
}
