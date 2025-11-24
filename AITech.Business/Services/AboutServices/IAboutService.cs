using AITech.Business.Services.GenericService;
using AITech.DTO.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.AboutServices
{
    public interface IAboutService:IGenericService<ResultAboutDto,CreateAboutDto, UpdateAboutDto>
    {
    }
}
