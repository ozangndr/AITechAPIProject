using AITech.DataAccess.Repositories.FAQRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.FAQDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.FAQServices
{
    public class FAQService(IFAQRepository _fAQRepository,IUnitOfWork _unitOfWork) : IFAQService
    {
        public async Task TCreateAsync(CreateFAQDto createDto)
        {
            var value = createDto.Adapt<FAQ>();
            await _fAQRepository.CreateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int Id)
        {
            var value= await _fAQRepository.GetByIdAsync(Id);
            if (value != null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            _fAQRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultFAQDto>> TGetAllAsync()
        {
            var values=await _fAQRepository.GetAllAsync();
            return values.Adapt<List<ResultFAQDto>>();

        }

        public async Task<ResultFAQDto> TGetByIdAsync(int id)
        {
            var value = await _fAQRepository.GetByIdAsync(id);
            if (value != null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            return value.Adapt<ResultFAQDto>();
        }

        public async Task TUpdateAsync(UpdateFAQDto updateDto)
        {
            var value = updateDto.Adapt<FAQ>();
            _fAQRepository.Update(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
