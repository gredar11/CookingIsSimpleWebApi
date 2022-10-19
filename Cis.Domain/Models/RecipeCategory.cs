﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Domain.Models
{
    public class RecipeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
