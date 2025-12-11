using AITech.Business.Services.GenericService;
using AITech.DTO.MessageDtos;

namespace AITech.Business.Services.MessageServices
{
    public interface IMessageService:IGenericService<ResultMessageDto,CreateMessageDto,UpdateMessageDto>
    {
    }

}
