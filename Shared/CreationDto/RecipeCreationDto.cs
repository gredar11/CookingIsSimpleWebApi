using Shared.GetResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CreationDto
{
    public record RecipeCreationDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
