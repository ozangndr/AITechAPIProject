using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.ChooseDtos
{
    public record CreateChooseDto(string Title, string Description, string Item1, string Item2, string Item3, string ImageUrl)
    {
    }
}
