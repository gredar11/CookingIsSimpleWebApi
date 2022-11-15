using Domain.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRecipesCategoryRepository
    {
        Task<PagedList<RecipeCategory>> GetRecipeCategories(RequestParameters requestParameters, bool trackChanges);

        void CreateCategory(RecipeCategory recipeCategory);
        Task<RecipeCategory> GetCategoryById(int id, bool trackChanges);
        Task<IEnumerable<RecipeCategory>> GetAllRecipeCategories(bool trackChanges);
        void DeleteCategory(int id);
    }
}
