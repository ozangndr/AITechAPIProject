using AITech.DataAccess.Repositories.StaffRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.StaffDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.StaffServices
{
    public class StaffService(IStaffRepository _staffRepository,IUnitOfWork _unitOfWork) : IStaffService
    {
        public async Task TCreateAsync(CreateStaffDto createDto)
        {
            var value = createDto.Adapt<Staff>();
            await _staffRepository.CreateAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int Id)
        {
            var value=await _staffRepository.GetByIdAsync(Id);
            _staffRepository.Delete(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultStaffDto>> TGetAllAsync()
        {
            var values=await _staffRepository.GetAllAsync();
            return values.Adapt<List<ResultStaffDto>>();
        }

        public async Task<ResultStaffDto> TGetByIdAsync(int id)
        {
            var value = await _staffRepository.GetByIdAsync(id);
            return value.Adapt<ResultStaffDto>();

        }

        public async Task TUpdateAsync(UpdateStaffDto updateDto)
        {
            var value=updateDto.Adapt<Staff>();
            _staffRepository.Update(value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
