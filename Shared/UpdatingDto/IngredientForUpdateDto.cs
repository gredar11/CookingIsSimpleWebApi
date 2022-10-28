using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UpdatingDto
{
    public class IngredientForUpdateDto
    {
        [MaxLength(50)]
        public string IngredientName { get; init; }
        [MaxLength(100)]
        public string? IngredientDescription { get; init; }
    }
}
