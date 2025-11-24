using AITech.DataAccess.Repositories.AboutItemRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.AboutItemDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.AboutItemServices
{
    public class AboutItemService(IAboutItemRepository _aboutItemRepository,IUnitOfWork _unitOfWork) : IAboutItemService
    {
        public async Task TCreateAsync(CreateAboutItemDto createDto)
        {
            var value = createDto.Adapt<AboutItem>();
            await _aboutItemRepository.CreateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int Id)
        {
            var value=await _aboutItemRepository.GetByIdAsync(Id);
            if (value == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            _aboutItemRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultAboutItemDto>> TGetAllAsync()
        {
            var values = await _aboutItemRepository.GetAllAsync();
            return values.Adapt<List<ResultAboutItemDto>>();
        }

        public async Task<ResultAboutItemDto> TGetByIdAsync(int id)
        {
            var value = await _aboutItemRepository.GetByIdAsync(id);
            if (value == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            return value.Adapt<ResultAboutItemDto>();
        }

        public async Task TUpdateAsync(UpdateAboutItemDto updateDto)
        {
            var value=updateDto.Adapt<AboutItem>();
            if (value == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            _aboutItemRepository.Update(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
