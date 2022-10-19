using Cis.Domain.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance.Repositories
{
    public class RecipeCategoryRepository : RepositoryBase<RecipeCategory>, IRecipesCategoryRepository
    {
        public RecipeCategoryRepository(CisDbContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateCategory(RecipeCategory recipeCategory)
        {
            await RepositoryContext.RecipeCategories.AddAsync(recipeCategory);
        }

        public async Task<IEnumerable<RecipeCategory>> GetAllRecipeCategories(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<RecipeCategory> GetCategoryById(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }
}
