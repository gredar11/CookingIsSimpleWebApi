using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GetResponseDto
{
    public record IngredientDto
    {
        public int Id { get; init; }
        public string IngredientName { get; init; }
        public string? IngredientDescription { get; init; }
    }
}
