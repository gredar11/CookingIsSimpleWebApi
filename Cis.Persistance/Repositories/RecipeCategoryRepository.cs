using Cis.Domain.Exceptions;
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
        public void CreateCategory(RecipeCategory recipeCategory)
        {
            RepositoryContext.RecipeCategories.AddAsync(recipeCategory);
        }

        public void DeleteCategory(int id)
        {
            var entity = FindByCondition(x => x.Id == id, true).SingleOrDefault();
            if (entity == null)
                throw new EntityNotFoundException<RecipeCategory>(id);
            Delete(entity);
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
