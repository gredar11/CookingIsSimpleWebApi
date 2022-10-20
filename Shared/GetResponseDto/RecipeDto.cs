using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GetResponseDto
{
    public record RecipeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public RecipeCategoryDto RecipeCategory { get; init; }
    }
}
