using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.GenericService
{
    public interface IGenericService<TResultDto,TCreateDto,TUpdateDto>
    {
        Task<List<TResultDto>> TGetAllAsync();
        Task<TResultDto> TGetByIdAsync(int id);
        Task TCreateAsync(TCreateDto createDto);
        Task TUpdateAsync(TUpdateDto updateDto);
        Task TDeleteAsync(int Id);
    }
}
