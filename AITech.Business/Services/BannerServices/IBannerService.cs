using AITech.Business.Services.GenericService;
using AITech.DataAccess.Repositories.GenericRapository;
using AITech.DTO.BannerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.BannerServices
{
    public interface IBannerService:IGenericService<ResultBannerDto,CreateBannerDto,UpdateBannerDto>
    {
    }
}
