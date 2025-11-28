using AITech.WebUI.DTOs.ChooseDtos;

namespace AITech.WebUI.Services.ChooseServices
{
    public interface IChooseService
    {
        Task<List<ResultChooseDto>> GetAllAsync();
        Task<UpdateChooseDto> GetByIdAsync(int id);
        Task CreateAsync(CreateChooseDto createChooseDto);
        Task UpdateAsync(UpdateChooseDto updateChooseDto);
        Task DeleteAsync(int id);
    }
}
