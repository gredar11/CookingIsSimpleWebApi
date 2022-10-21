using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CreationDto
{
    public record FoodCategoryForCreationDto
    {
        public string NameOfCategory { get; init; }
        public string Description { get; init; }
        //public IEnumerable<IngredientForCreationDto>? Ingredients { get; init; }
    }
}
