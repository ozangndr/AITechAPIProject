using AITech.DataAccess.Repositories.BannerRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.BannerDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.BannerServices
{
    public class BannerService(IBannerRepository _bannerRepository,IUnitOfWork _unitOfWork) : IBannerService
    {
        public async Task TCreateAsync(CreateBannerDto createDto)
        {
            var value = createDto.Adapt<Banner>();
            await _bannerRepository.CreateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int Id)
        {
            var value=await _bannerRepository.GetByIdAsync(Id);
            _bannerRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultBannerDto>> TGetAllAsync()
        {
            var values=await _bannerRepository.GetAllAsync();
            return values.Adapt<List<ResultBannerDto>>();
        }

        public async Task<ResultBannerDto> TGetByIdAsync(int id)
        {
            var value=await _bannerRepository.GetByIdAsync(id);
            if (value == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            return value.Adapt<ResultBannerDto>();
        }

        public async Task TUpdateAsync(UpdateBannerDto updateDto)
        {
            var value=updateDto.Adapt<Banner>();
            if (value == null)
            {
                throw new Exception("Kayıt Bulunamadı");
            }
            _bannerRepository.Adapt(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
