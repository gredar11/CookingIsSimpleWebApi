using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string? IngredientDescription { get; set; }
        public int CategoryId { get; set; }
        public FoodCategory Category { get; set; }
        public IEnumerable<AmountOfIngredient> Recipes { get; set; }
    }
}
