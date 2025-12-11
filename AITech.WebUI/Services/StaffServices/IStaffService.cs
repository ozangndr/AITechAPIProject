using AITech.WebUI.DTOs.StaffDtos;

namespace AITech.WebUI.Services.StaffServices
{
    public interface IStaffService
    {
        Task<List<ResultStaffDto>> GetAllAsync();
        Task<UpdateStaffDto> GetByIdAsync(int id);
        Task CreateAsync(CreateStaffDto createStaffDto);
        Task UpdateAsync(UpdateStaffDto updateStaffDto);
        Task DeleteAsync(int id);
    }
}
