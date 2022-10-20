using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GetResponseDto
{
    public record AmountOfIngredientDto
    {
        public int IngredientId { get; init; }
        public int RecipeId { get; init; }
        public double Amount { get; init; }
        public IngredientDto Ingredient { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}
