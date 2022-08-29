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

        public void AddEntity(Ingredient ingredient)
        {
            var res = _cisDbcontext.Add(ingredient).State;
            _cisDbcontext.SaveChanges();
        }

        public List<Ingredient> GetAllEntities()
        {
            return _cisDbcontext.Ingredients.ToList();
        }

        public Ingredient GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveEntity(int id)
        {
            var identity = _cisDbcontext.Ingredients.Find(id);
            if (identity != null)
            {
                var res = _cisDbcontext.Ingredients.Remove(identity);
                _cisDbcontext.SaveChanges();
            }
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Ingredient ingredient)
        {
            var entityInDb = _cisDbcontext.Ingredients
                .Where(x => x.Id == ingredient.Id).SingleOrDefault();
            if (entityInDb == null)
                return;
            entityInDb.IngredientName = ingredient.IngredientName;
            entityInDb.IngredientDescription = ingredient.IngredientDescription;
            _cisDbcontext.SaveChanges();
        }
    }
}
