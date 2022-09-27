﻿using Cis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFoodCategoryRepository
    {
        Task<IEnumerable<FoodCategory>> GetFoodCategories();
    }
}
