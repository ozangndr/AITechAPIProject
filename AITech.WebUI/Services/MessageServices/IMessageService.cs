using AITech.WebUI.DTOs.MessageDtos;

namespace AITech.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllAsync();
        Task<UpdateMessageDto> GetByIdAsync(int id);
        Task CreateAsync(CreateMessageDto createMessageDto);
        Task UpdateAsync(UpdateMessageDto updateMessageDto);
        Task DeleteAsync(int id);
    }
}
