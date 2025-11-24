using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.AboutDtos
{
    public record CreateAboutDto(string Title, string Description, string ImageUrl)
    {
    }
}
