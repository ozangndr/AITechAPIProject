using AITech.Business.Services.GenericService;
using AITech.DTO.ProjectDtos;
using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Business.Services.ProjectServices
{
    public interface IProjectService:IGenericService<ResultProjectDto,CreateProjectDto,UpdateProjectDto>
    {
        Task<List<ResultProjectDto>> TGetProjectWithCategoriesAsync();
    }
}
