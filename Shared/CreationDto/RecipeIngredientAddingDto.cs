using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CreationDto
{
    public record RecipeIngredientAddingDto
    {
        public double Amount { get; init; }
    }
}
