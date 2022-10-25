using Cis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRecipesCategoryRepository
    {
        void CreateCategory(RecipeCategory recipeCategory);
        Task<RecipeCategory> GetCategoryById(int id, bool trackChanges);
        Task<IEnumerable<RecipeCategory>> GetAllRecipeCategories(bool trackChanges);
        void DeleteCategory(int id);
    }
}
