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
        public void CreateIngredient(Ingredient ingredient)
        {
            Create(ingredient);
        }

        public void DeleteIngredientById(Ingredient ingredient)
        {
            Delete(ingredient);
        }

        public async Task<Ingredient> GetIngredientById(int id, bool trackChanges)
        {
            return await FindByCondition(ingredient => ingredient.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }
    }
}
