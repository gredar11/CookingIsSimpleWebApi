using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GetResponseDto
{
    public record RecipeCategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
