using Cis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cis.Persistance.Repositories
{
    public class FoodCategoryRepository : IRepository<FoodCategory>
    {
        private readonly CisDbContext _cisDbcontext;
        public FoodCategoryRepository(CisDbContext cisDbcontext)
        {
            _cisDbcontext = cisDbcontext;
        }

        public async Task<int> AddEntity(FoodCategory post)
        {
            _cisDbcontext.FoodCategories.Add(post);
            var res = await _cisDbcontext.SaveChangesAsync();
            return res;
        }

        public async Task<List<FoodCategory>> GetAllEntities()
        {
            var res = await _cisDbcontext.FoodCategories.ToListAsync();
            return res;
        }

        public async Task<FoodCategory> GetEntity(int id)
        {
            var res = await _cisDbcontext.FoodCategories.FindAsync(id);
            return res;
        }

        public async Task RemoveEntity(int id)
        {
            var entityToRemove = _cisDbcontext.FoodCategories.Find(id);
            _cisDbcontext.FoodCategories.Remove(entityToRemove);
            await _cisDbcontext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            var res = await _cisDbcontext.SaveChangesAsync();
            return res;
        }

        public async Task UpdateEntity(FoodCategory post)
        {
            _cisDbcontext.FoodCategories.Update(post);
            await _cisDbcontext.SaveChangesAsync();
        }
    }
}
