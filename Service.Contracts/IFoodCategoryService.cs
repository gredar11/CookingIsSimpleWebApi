using Cis.Domain.Models;
using Shared.CreationDto;
using Shared.GetResponseDto;
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
        Task<IEnumerable<FoodCategoryDto>> GetFoodCategories(bool trackChanges);
        Task<FoodCategoryDto> GetFoodCategoryById(int id, bool trackChanges);
        Task DeleteFoodCategory(int foodCategoryId, bool trackChanges);
        Task UpdateFoodCategory(int id , FoodCategoryForUpdateDto updateDto, bool trackChanges);
        Task<FoodCategoryDto> CreateFoodCategory(FoodCategoryForCreationDto creationDto);
    }
}
