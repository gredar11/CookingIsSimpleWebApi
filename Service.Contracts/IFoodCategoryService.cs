using Cis.Domain.Models;
using Shared.CreationDto;
using Shared.GetResponseDto;
using Shared.RequestFeatures;
using Shared.UpdatingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFoodCategoryService
    {
        Task<FoodCategoryDto> CreateFoodCategory(FoodCategoryForCreationDto creationDto);
        Task<(IEnumerable<FoodCategoryDto> dtos, PageMetaData metaData)> GetFoodCategories(RequestParameters requestParameters, bool trackChanges);
        Task<FoodCategoryDto> GetFoodCategoryById(int id, bool trackChanges);
        Task UpdateFoodCategory(int id , FoodCategoryForUpdateDto updateDto, bool trackChanges);
        Task DeleteFoodCategory(int foodCategoryId, bool trackChanges);
        Task<(FoodCategoryForUpdateDto foodCategoryToPatch, FoodCategory foodCategoryEntity)> GetFoodCategoryForPatch(int id, bool trackChanges);
        Task SaveChangesForPatch(FoodCategoryForUpdateDto foodCategoryToPatch, FoodCategory foodCategoryEntity);
    }
}
