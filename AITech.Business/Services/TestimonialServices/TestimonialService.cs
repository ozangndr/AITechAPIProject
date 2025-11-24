using AITech.DataAccess.Repositories.TestimonialRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.CategoryDtos;
using AITech.DTO.TestimonialDtos;
using AITech.Entity.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.TestimonialServices
{
    public class TestimonialService(ITestimonialRepository _testimonialRepository,IUnitOfWork unitOfWork) : ITestimonialService
    {
        public async Task TCreateAsync(CreateTestimonialDto createDto)
        {
            var value = createDto.Adapt<Testimonial>();
            await _testimonialRepository.CreateAsync(value);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task TDeleteAsync(int Id)
        {
           var value =await  _testimonialRepository.GetByIdAsync(Id);
            if (value is null)
            {
                throw new Exception("Değer Bulunamadı");
            }
            _testimonialRepository.Delete(value);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultTestimonialDto>> TGetAllAsync()
        {
            var values =await _testimonialRepository.GetAllAsync();
            return values.Adapt<List<ResultTestimonialDto>>();
        }

        public async Task<ResultTestimonialDto> TGetByIdAsync(int id)
        {
            var value =await _testimonialRepository.GetByIdAsync(id);
            if (value is null)
            {
                throw new Exception("Değer Bulunamadı");
            }
            return value.Adapt<ResultTestimonialDto>();
        }

        public Task TUpdateAsync(UpdateTestimonialDto updateDto)
        {
            var value=updateDto.Adapt<Testimonial>();
            _testimonialRepository.Update(value);
            return unitOfWork.SaveChangesAsync();
        }
    }
}
