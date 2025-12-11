using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.StaffDtos
{
    public record UpdateStaffDto(int Id, string Name, string Title, string ImageUrl, string Social1, string Social2, string Social3, string Social4);
}
