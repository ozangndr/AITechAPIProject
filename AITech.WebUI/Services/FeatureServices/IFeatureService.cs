using AITech.WebUI.DTOs.FeatureDtos;

namespace AITech.WebUI.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllAsync();
        Task<UpdateFeatureDto> GetByIdAsync(int id);
        Task CreateAsync(CreateFeatureDto createFeatureDto);
        Task UpdateAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteAsync(int id);
    }
}
