using Cis.Domain.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
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

        public async Task<PagedList<FoodCategory>> GetFoodCategories(RequestParameters requestParameters, bool trackChanges)
        {
            var res = await FindAll(trackChanges)
                        .Skip((requestParameters.PageNumber - 1) * requestParameters.PageSize)
                        .Take(requestParameters.PageSize)
                        .OrderBy(c => c.NameOfCategory)
                        .ToListAsync();
            return new PagedList<FoodCategory>(res, RepositoryContext.FoodCategories.Count(), requestParameters.PageNumber, requestParameters.PageSize);
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
