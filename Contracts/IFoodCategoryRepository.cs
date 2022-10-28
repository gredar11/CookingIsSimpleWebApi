using Cis.Domain.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFoodCategoryRepository
    {
        Task<PagedList<FoodCategory>> GetFoodCategories(RequestParameters requestParameters, bool trackChanges);
        Task<FoodCategory> GetFoodCategoryById(int id, bool trackChanges);
        Task CreateFoodCategory(FoodCategory foodCategory);
        void UpdateFoodCategory(FoodCategory foodCategory);
        void DeleteFoodCategory(FoodCategory foodCategory);
    }
}
