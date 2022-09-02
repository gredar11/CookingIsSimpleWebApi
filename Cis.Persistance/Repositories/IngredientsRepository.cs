using Cis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance.Repositories
{
    public class IngredientsRepository : IRepository<Ingredient>
    {
        private readonly CisDbContext _cisDbcontext;
        public IngredientsRepository(CisDbContext cisDbContext)
        {
            _cisDbcontext = cisDbContext;
        }

        public async Task<int> AddEntity(Ingredient ingredient)
        {
            var result = await _cisDbcontext.AddAsync(ingredient);
            await SaveChangesAsync();
            return result.Property(p => p.Id).CurrentValue;
        }

        public async Task<List<Ingredient>> GetAllEntities()
        {
            return await _cisDbcontext.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> GetEntity(int id)
        {
            var entity = await _cisDbcontext.Ingredients.FindAsync(id);
            if (entity != null)
                return entity;
            return null;
        }

        public async Task RemoveEntity(int id)
        {
            var identity = _cisDbcontext.Ingredients.Find(id);
            if (identity != null)
            {
                var res = _cisDbcontext.Ingredients.Remove(identity);
                await SaveChangesAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _cisDbcontext.SaveChangesAsync();
            return result;
        }

        public async Task UpdateEntity(Ingredient ingredient)
        {
            var entityInDb = _cisDbcontext.Ingredients
                .Where(x => x.Id == ingredient.Id).SingleOrDefault();
            if (entityInDb == null)
                return ;
            entityInDb.IngredientName = ingredient.IngredientName;
            entityInDb.IngredientDescription = ingredient.IngredientDescription;
            await SaveChangesAsync();
        }
    }
}
