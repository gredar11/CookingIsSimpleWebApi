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
    public class IngredientsRepository : RepositoryBase<Ingredient>, IIngreditentRepository
    {
        public IngredientsRepository(CisDbContext repositoryContext):base(repositoryContext)
        {

        }
        public void CreateIngredient(int categoryId, Ingredient ingredient)
        {
            ingredient.CategoryId = categoryId;
            Create(ingredient);
        }

        public void DeleteIngredientById(Ingredient ingredient)
        {
            Delete(ingredient);
        }

        public async Task<Ingredient> GetIngredientById(int categoryId, int id, bool trackChanges)
        {
            return await FindByCondition(ingredient => ingredient.Id == id && ingredient.CategoryId == categoryId, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients(int categoryId, bool trackChanges)
        {
            return await FindByCondition(ingr => ingr.CategoryId.Equals(categoryId), trackChanges).OrderBy(ingr => ingr.IngredientName).ToListAsync();
        }
    }
}
