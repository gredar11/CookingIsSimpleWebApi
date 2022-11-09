using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UpdatingDto
{
    public record class AmountOfIngredientToAddIntoRecipeDto(int IngredientId, int RecipeId, double Amount);
}
