using Cis.Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFoodCategoryService
    {
        Task<IEnumerable<FoodCategoryDto>> GetFoodCategories();
    }
}
