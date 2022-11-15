using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? RecipeCategoryId { get; set; }
        public RecipeCategory? RecipeCategory { get; set; }
        public IEnumerable<AmountOfIngredient> Ingredients { get; set; }
    }
}
