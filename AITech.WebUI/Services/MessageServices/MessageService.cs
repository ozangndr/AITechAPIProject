using AITech.WebUI.DTOs.MessageDtos;

namespace AITech.WebUI.Services.MessageServices
{
    public class MessageService:IMessageService
    {
        private readonly HttpClient _client;

        public MessageService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7144/api/");
            _client = client;
        }

        public async Task CreateAsync(CreateMessageDto dto)
        {
            await _client.PostAsJsonAsync("Messages", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _client.DeleteAsync("Messages/" + id);
        }

        public async Task<List<ResultMessageDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultMessageDto>>("Messages");
        }

        public async Task<UpdateMessageDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateMessageDto>("Messages/" + id);
        }

        public async Task UpdateAsync(UpdateMessageDto dto)
        {
            await _client.PutAsJsonAsync("Messages", dto);

        }
    }
}
