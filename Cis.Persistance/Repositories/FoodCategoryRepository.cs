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
    public class FoodCategoryRepository : RepositoryBase<FoodCategory>, IFoodCategoryRepository
    {
        public FoodCategoryRepository(CisDbContext cisDbContext) : base(cisDbContext)
        {

        }
        public async Task CreateFoodCategory(FoodCategory foodCategory)
        {
            await RepositoryContext.FoodCategories.AddAsync(foodCategory);
        }

        public void DeleteFoodCategory(FoodCategory foodCategory)
        {
            Delete(foodCategory);
        }

        public async Task<IEnumerable<FoodCategory>> GetFoodCategories(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<FoodCategory> GetFoodCategoryById(int id, bool trackChanges)
        {
            return await FindByCondition(f => f.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateFoodCategory(FoodCategory foodCategory)
        {
            Update(foodCategory);
        }
    }
}
