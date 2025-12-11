using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.MessageDtos
{
    public record UpdateMessageDto(int Id, string? Name, string? Email, string? Subject, string? Body)
    {
    }

}
