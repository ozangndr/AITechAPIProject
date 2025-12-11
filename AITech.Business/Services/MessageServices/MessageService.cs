using AITech.DataAccess.Repositories.MessageRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.MessageDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.MessageServices
{
    public class MessageService(IMessageRepository _messageRepository,IUnitOfWork _unitOfWork) : IMessageService
    {
        public async Task TCreateAsync(CreateMessageDto createDto)
        {
            var value = createDto.Adapt<Message>();
            await _messageRepository.CreateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int Id)
        {
            var value=await _messageRepository.GetByIdAsync(Id);
            if(value is null)
            {
               throw new Exception("Kayıt Bulunamadı");
            }
            _messageRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> TGetAllAsync()
        {
            var values=await _messageRepository.GetAllAsync();
            return values.Adapt<List<ResultMessageDto>>();
        }

        public async Task<ResultMessageDto> TGetByIdAsync(int id)
        {
            var value=await _messageRepository.GetByIdAsync(id);
            if(value is null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            return value.Adapt<ResultMessageDto>();
        }

        public Task TUpdateAsync(UpdateMessageDto updateDto)
        {
            var value = updateDto.Adapt<Message>();
            _messageRepository.Update(value);
            return _unitOfWork.SaveChangesAsync();
        }
    }
}
