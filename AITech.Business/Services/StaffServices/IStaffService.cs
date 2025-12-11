using AITech.Business.Services.GenericService;
using AITech.DTO.StaffDtos;
using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.StaffServices
{
    public interface IStaffService:IGenericService<ResultStaffDto,CreateStaffDto,UpdateStaffDto>
    {
    }
}
