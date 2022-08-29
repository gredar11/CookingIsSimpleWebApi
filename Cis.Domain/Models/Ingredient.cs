using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; } = "";
        public string? IngredientDescription { get; set; }


    }
}
