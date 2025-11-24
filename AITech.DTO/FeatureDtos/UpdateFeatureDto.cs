using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DTO.FeatureDtos
{
    public record UpdateFeatureDto(int Id, string Title, string Icon, string Description)
    {
    }
}
