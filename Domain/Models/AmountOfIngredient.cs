using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Models
{
    public class AmountOfIngredient
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        [Range(minimum:0.0, maximum:10_000.0)]
        public double Amount { get; set; } 
    }
}
