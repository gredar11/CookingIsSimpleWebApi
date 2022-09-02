using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }
        public string NameOfCategory { get; set; }
        public string Description { get; set; }
        public IEnumerable<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
    }
}
