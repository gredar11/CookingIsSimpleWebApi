using Cis.Domain.Models;
using Shared;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IIngredientService
    {
        Task<(IEnumerable<IngredientDto>, PageMetaData)> GetAllIngredientsFromFoodCategory(int foodCategoryId, IngredientParameters ingredientParameters, bool trackChanges);
        Task<IngredientDto> GetIngredientFromFoodCategoryById(int categoryId, int ingredientId, bool trackChanges);
        Task DeleteIngredient(int categoryId, int ingredientId, bool trackChanges);
        Task<IngredientDto> CreateIngredientForCategory(int categoryId, IngredientForCreationDto forCreationDto, bool trackChanges);
        Task UpdateIngredientForCategory(int categoryId, int ingredientId, IngredientForUpdateDto updateDto, bool trackChanges);


    }
}
